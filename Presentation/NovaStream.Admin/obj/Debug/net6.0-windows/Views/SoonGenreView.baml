   M S B A M L   `   `   `  ����  NovaStream.Admin*    $NovaStream.Admin.Views.SoonGenreView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Soon Genres��6   $��32(�6'   $��SemiBold"�65   $��0 20 0 0q�6K   $
��Left=�5      ���#1215186/   �� 5   
      	AddButton#��[  6   ��64   �� *OpenAddDialogHostCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6X   $��0 1 8 0q�6s   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size 116s   �� 5      $��Add New Soon Genre��6   5      5      �� 5   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0 10 0 0q�6;   .+�5       �� -   5        $��Soons��5         	TabButton#��[ 6D   �� 5!      $��Genres��6   #��[ 6&     AppColor#��[ 6I   5"      �� 5$   
   $��3��6T   $��18(�6a   $��SemiBold"�6o   ���#121518$
��Left=�5%   )   $��Center=�6D   ��5$      �� *SoonGenreCount+ �� StringFormat$ {0} Soon Genres��5%   D   �� 5'   
    & "MaterialDesignIconForegroundButton#��[ 6e   ���#121518$��	130 0 0 0q�5(   )   $
��Left=�6<   $��Center=�6W   $��3��6r   ��5'        $ Refresh=���6B   �� *RefreshCommand+5(   r   �� 5*   
   $��	Filter by��6   $��3��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�5+   )   $��Center=�6E   � 5-   
   $	��200��6   $��Right=�6   $��3��67   .+�5.      �� $
��15 0q�6   $��Center=�6&   ���#b0b9c6 J� IsHitTestVisible$ False��6V    K� ZIndex$ 1��5/      $��Search in Soon Genres...��6)   y�50      ��  �� ElementName$ 	txtSearch�� �� Path$ Text.IsEmpty�   BooleanToVisibilityConverter	 �� 	Converter#	 [ �� 52      -   5        
 ��Name$
 	txtSearch��52        TextboxFilter#��[ 6)   .��6P   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 53      +  %Microsoft.Xaml.Behaviors.EventTrigger  54         	EventName$ TextChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 55      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SearchCommand+   CommandParameter 6R   �� $ 	txtSearch��$
 Text�56      .��57   *   58      59      &   System.Windows.Controls.DataGrid  5;   
   -   5          Name$ ItemsDataGrid��5;        DataGridStyle1#��[ 6M     DataGridCellStyle1   	CellStyle# [ 6u     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 6�    	 DataGridRowStyle1   RowStyle# [	 6�   $��4��6  ��6*   �� *
SoonGenres+   Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Soon Name��6%      
IsReadOnly$
 True��6U      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 6g   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 68   �� *
SoonName+6g     5?      $ 
Genre Name��6%   $
 True��6X   $ *	 6j    69   �� *
Genre.Name+6j   4  .System.Windows.Controls.DataGridTemplateColumn  5A      $ 
Operations��6)   $
 True��6=   $
 auto	 6O      CellTemplate 5B      �� 5C      .R�5D      ��  
 GridRemoveButton#��[
 6%   $��5 0 0 0q�6#  ��6O   ��  �� RelativeSource ��  �� AncestorType UserControl �� Mode$ FindAncestor=�$ DataContext.DeleteCommand���6�   ��  �� *Self+$ DataContext�.��5E   "   �� $��Center=�6q   ��61     $ DeleteOutline=� 126q   5F      5G      5I      5L      5N      5P      