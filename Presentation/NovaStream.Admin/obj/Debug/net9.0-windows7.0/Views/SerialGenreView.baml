   M S B A M L   `   `   `  ����  NovaStream.Admin,    &NovaStream.Admin.Views.SerialGenreView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Serial Genres��6   $��32(�6)   $��SemiBold"�67   $��0 20 0 0q�6M   $
��Left=�5      ���#1215186/   �� 5   
      	AddButton#��[  6   ��64   �� *OpenAddDialogHostCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6X   $��0 1 8 0q�6s   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size 116s   �� 5      $��Add New Serial Genre��6   5      5      �� 5   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0 10 0 0q�6;   .+�5       �� -   5        $��Serials��5         	TabButton#��[ 6H   �� 5!      -   5        $��Actors��5!      #��[ 6L   �� 5"      $��Genres��6   #��[ 6&     AppColor#��[ 6I   5#      �� 5%   
   $��3��6X   $��18(�6e   $��SemiBold"�6s   ���#121518$
��Left=�5&   )   $��Center=�6D   ��5%      �� *SerialGenreCount+ �� StringFormat$ {0} Serial Genres��5&   D   �� 5(   
    & "MaterialDesignIconForegroundButton#��[ 6e   ���#121518$��	130 0 0 0q�5)   )   $
��Left=�6<   $��Center=�6W   $��3��6r   ��5(        $ Refresh=���6B   �� *RefreshCommand+5)   r   �� 5+   
   $��	Filter by��6   $��3��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�5,   )   $��Center=�6E   � 5.   
   $	��200��6   $��Right=�6   $��3��67   .+�5/      �� $
��15 0q�6   $��Center=�6&   ���#b0b9c6 J� IsHitTestVisible$ False��6V    K� ZIndex$ 1��50      $ ��Search in Serial Genres...��6)   y�51      ��  �� ElementName$ 	txtSearch�� �� Path$ Text.IsEmpty�   BooleanToVisibilityConverter	 �� 	Converter#	 [ �� 53      -   5        
 ��Name$
 	txtSearch��53        TextboxFilter#��[ 6)   .��6P   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 54      +  %Microsoft.Xaml.Behaviors.EventTrigger  55         	EventName$ TextChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 56      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SearchCommand+   CommandParameter 6R   �� $ 	txtSearch��$
 Text�57      .��58   *   59      5:      &   System.Windows.Controls.DataGrid  5<   
   -   5          Name$ ItemsDataGrid��5<       �� SelectedIndex$ 0��6*     DataGridStyle1#��[ 6a     DataGridCellStyle1   	CellStyle# [ 6�     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 6�    	 DataGridRowStyle1   RowStyle# [	 6�   $��4��6'  ��6<   �� *SerialGenres+   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Serial Name��6%      
IsReadOnly$
 True��6Y      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 6k   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6:   �� *
SerialName+6k     5@      $ 
Genre Name��6%   $
 True��6X   $ *	 6j    69   �� *
Genre.Name+6j   4  .System.Windows.Controls.DataGridTemplateColumn  5B      $ 
Operations��6)   $
 True��6=   $
 auto	 6O      CellTemplate 5C      �� 5D      .R�5E      ��  
 GridRemoveButton#��[
 6%   $��5 0 0 0q�6#  ��6O   ��  �� RelativeSource ��  �� AncestorType UserControl �� Mode$ FindAncestor=�$ DataContext.DeleteCommand���6�   ��  �� *Self+$ DataContext�.��5F   "   �� $��Center=�6q   ��61     $ DeleteOutline=� 126q   5G      5H      5J      5M      5O      5Q      