﻿namespace NovaStream.Admin.ViewModels.DialogHosts;

public class AddActorViewModel : DependencyObject
{
    private readonly AppDbContext _dbContext;
    private readonly IStorageManager _storageManager;
    
    public ActorViewModelContent Actor { get; set; }

    public bool ProcessStarted
    {
        get { return (bool)GetValue(ProcessStartedProperty); }
        set { SetValue(ProcessStartedProperty, value); }
    }
    public static readonly DependencyProperty ProcessStartedProperty =
        DependencyProperty.Register("ProcessStarted", typeof(bool), typeof(AddActorViewModel));
    
    public List<Task> UploadTasks { get; set; }
    public List<CancellationTokenSource> UploadTaskTokens { get; set; }

    public RelayCommand SaveCommand { get; set; }
    public RelayCommand CancelCommand { get; set; }
    public RelayCommand OpenImageDialogCommand { get; set; }


    public AddActorViewModel(AppDbContext dbContext, IStorageManager storageManager)
    {
        _dbContext = dbContext;
        _storageManager = storageManager;

        Actor = new();

        UploadTasks = new();
        UploadTaskTokens = new();

        SaveCommand = new RelayCommand(() => Save());
        CancelCommand = new RelayCommand(() => Cancel());

        OpenImageDialogCommand = new RelayCommand(() => Actor.ImageUrl = FileDialogService.OpenImageFile(Actor.ImageUrl));
    }


    private async Task Save()
    {
        await Task.CompletedTask;

        if (!InternetService.CheckInternet()) { await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error); return; }

        try
        {
            Actor.Verify();

            if (Actor.HasErrors) return;
            
            ProcessStarted = true;

            var actor = Actor.Adapt<Actor>();

            var dbActor = _dbContext.Actors.FirstOrDefault(a => a.Id == Actor.Id);

            UploadTasks.Clear();
            UploadTaskTokens.Clear();

            Actor.ImageUploadSuccess = false;

            // Actor ImageUrl
            if (dbActor is null || dbActor is not null && dbActor.ImageUrl != Actor.ImageUrl)
            {
                var imageStream = new FileStream(Actor.ImageUrl, FileMode.Open, FileAccess.Read);
                var filename = string.Format("{0}-image-{1}{2}", $"{Actor.Name} {Actor.Surname}".Replace(' ', '-'), Random.Shared.Next(), Path.GetExtension(Actor.ImageUrl));
                actor.ImageUrl = string.Format("Images/Actors/{0}", filename);

                Actor.ImageProgress = new BlobStorageUploadProgress(imageStream.Length);

                if (dbActor is not null) _ = _storageManager.DeleteFileAsync(dbActor.ImageUrl);

                var imageToken = new CancellationTokenSource();
                var imageUploadTask = _storageManager.UploadFileAsync(imageStream, actor.ImageUrl, Actor.ImageProgress, imageToken.Token);

                UploadTasks.Add(imageUploadTask);
                UploadTaskTokens.Add(imageToken);

                imageUploadTask.ContinueWith(_ => Actor.ImageUploadSuccess = true);
            }

            if (UploadTasks.Count > 0) await Task.WhenAll(UploadTasks);

            var actorViewModel = App.ServiceProvider.GetService<ActorViewModel>();

            if (dbActor is not null)
            {
                var entity = actorViewModel.Actors.FirstOrDefault(a => a.Id == dbActor.Id);
                _dbContext.Entry(entity).State = EntityState.Detached;

                var index = actorViewModel.Actors.IndexOf(entity);
                actorViewModel.Actors.RemoveAt(index);

                actor.Id = dbActor.Id;
                _dbContext.Actors.Update(actor);

                actorViewModel.Actors.Insert(index, actor);
            }
            else
            {
                _dbContext.Actors.Add(actor);
                actorViewModel.Actors.Add(actor);
            }

            await _dbContext.SaveChangesAsync();

            Actor.ImageUploadSuccess = true;

            ProcessStarted = false;

            DialogHost.Close("RootDialog");

            await MessageBoxService.Show("Actor saved succesfully!", MessageBoxType.Success);
        }
        catch (OperationCanceledException) { return; }
        catch
        {
            if (!InternetService.CheckInternet())
                await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error);

            else
                await MessageBoxService.Show("Server not responding please try again later!", MessageBoxType.Error);

            await Cancel();
        }
    }

    private async Task Cancel()
    {
        ProcessStarted = false;

        UploadTaskTokens.ForEach(ts => ts.Cancel());

        Actor.ImageProgress.Progress = 0;
        if (Actor.ImageUploadSuccess) await _storageManager.DeleteFileAsync(Actor.ImageUrl);
    }
}
