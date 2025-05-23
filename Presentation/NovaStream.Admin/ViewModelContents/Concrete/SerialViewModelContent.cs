﻿namespace NovaStream.Admin.ViewModelContents.Concrete;

public class SerialViewModelContent : ViewModelContentBase
{
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;

            OnPropertyChanged();
            
            ClearErrors(nameof(Name));

            if (string.IsNullOrWhiteSpace(_name)) AddError(nameof(Name), $"{nameof(Name)} cannot be empty!");
        }
    }

    private int _year = DateTime.Now.Year;
    public int Year
    {
        get => _year;
        set
        {
            _year = value;

            OnPropertyChanged();

            ClearErrors(nameof(Year));

            if (_year > DateTime.Now.Year) AddError(nameof(Year), "Serial release date can't be in the future!");
            else if (_year < 1900) AddError(nameof(Year), "There were no films at that time.");
        }
    }

    private int _age;
    public int Age
    {
        get => _age;
        set
        {
            _age = value;

            OnPropertyChanged();

            ClearErrors(nameof(Age));

            if (_age == 0) AddError(nameof(Age), $"{nameof(Age)} cannot be empty!");
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            _description = value;

            OnPropertyChanged();

            ClearErrors(nameof(Description));

            if (string.IsNullOrWhiteSpace(_description)) AddError(nameof(Description), $"{nameof(Description)} cannot be empty!");
                    }
    }

    private string _trailerUrl;
    public string TrailerUrl
    {
        get => _trailerUrl;
        set
        {
            _trailerUrl = value;

            OnPropertyChanged();

            ClearErrors(nameof(TrailerUrl));

            if (string.IsNullOrWhiteSpace(_trailerUrl)) { AddError(nameof(TrailerUrl), $"{nameof(TrailerUrl).Replace("Url", string.Empty)} path cannot be empty!"); return; }
            else if (_trailerUrl[1] != ':') return;
            else if (!File.Exists(_trailerUrl)) { AddError(nameof(TrailerUrl), "File with this path not exists!"); return; }

            var size = Convert.ToDecimal(new FileInfo(_trailerUrl).Length) / (1024 * 1024);

            if (size > FileDialogService.MaxTrailerSize) AddError(nameof(TrailerUrl), $"File size cannot exceed {FileDialogService.MaxTrailerSize}mb");
        }
    }

    private string _imageUrl;
    public string ImageUrl
    {
        get => _imageUrl;
        set
        {
            _imageUrl = value;

            OnPropertyChanged();

            ClearErrors(nameof(ImageUrl));

            if (string.IsNullOrWhiteSpace(_imageUrl)) { AddError(nameof(ImageUrl), $"{nameof(ImageUrl).Replace("Url", string.Empty)} path cannot be empty!"); return; }
            else if (_imageUrl[1] != ':') return;
            else if (!File.Exists(_imageUrl)) { AddError(nameof(ImageUrl), "File with this path not exists!"); return; }

            var size = Convert.ToDecimal(new FileInfo(_imageUrl).Length) / 1024;

            if (size > FileDialogService.MaxImageSize) AddError(nameof(ImageUrl), $"File size cannot exceed {FileDialogService.MaxImageSize / 1024}mb");
        }
    }

    private string _searchImageUrl;
    public string SearchImageUrl
    {
        get => _searchImageUrl;
        set
        {
            _searchImageUrl = value;

            OnPropertyChanged();

            ClearErrors(nameof(SearchImageUrl));

            if (string.IsNullOrWhiteSpace(_searchImageUrl)) { AddError(nameof(SearchImageUrl), "Search Image path cannot be empty!"); return; }
            else if (_searchImageUrl[1] != ':') return;
            else if (!File.Exists(_searchImageUrl)) { AddError(nameof(SearchImageUrl), "File with this path not exists!"); return; }

            var size = Convert.ToDecimal(new FileInfo(_searchImageUrl).Length) / 1024;
            
            if (size > FileDialogService.MaxImageSize) AddError(nameof(SearchImageUrl), $"File size cannot exceed {FileDialogService.MaxImageSize / 1024}mb");
        }
    }


    private Director _director;
    public Director Director
    {
        get => _director;
        set
        {
            _director = value;

            OnPropertyChanged();

            ClearErrors(nameof(Director));

            if (_director is null) AddError(nameof(Director), $"{nameof(Director)} cannot be empty!");
        }
    }


    private BlobStorageUploadProgress _trailerProgress;
    public BlobStorageUploadProgress TrailerProgress
    {
        get => _trailerProgress;
        set { _trailerProgress = value; OnPropertyChanged(); }
    }

    private BlobStorageUploadProgress _imageProgress;
    public BlobStorageUploadProgress ImageProgress
    {
        get => _imageProgress;
        set { _imageProgress = value; OnPropertyChanged(); }
    }

    private BlobStorageUploadProgress _searchImageProgress;
    public  BlobStorageUploadProgress SearchImageProgress
    {
        get => _searchImageProgress;
        set { _searchImageProgress = value; OnPropertyChanged(); }
    }

    public bool TrailerUploadSuccess { get; set; }
    public bool ImageUploadSuccess { get; set; }
    public bool SearchImageUploadSuccess { get; set; }


    public override void Verify()
    {
        Name = Name is null ? Name : Name.Trim();
        Year = Year;
        Age = Age;
        Description = Description is null ? Description : Description.Trim();
        TrailerUrl = TrailerUrl;
        ImageUrl = ImageUrl;
        SearchImageUrl = SearchImageUrl;
        Director = Director;
    }
}
