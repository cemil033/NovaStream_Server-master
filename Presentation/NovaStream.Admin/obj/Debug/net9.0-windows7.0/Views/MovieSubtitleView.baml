   M S B A M L   `   `   `  ����  NovaStream.Admin.    (NovaStream.Admin.Views.MovieSubtitleView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��	Subtitles��6   $��32(�6%   $��SemiBold"�63   $��0 20 0 0q�6I   $
��Left=�5      ���#1215186   �� 5   
      	AddButton#��[  6   ��64   �� *OpenAddDialogHostCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6X   $��0 1 8 0q�6s   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size 116s   �� 5      $��Add New Movie Subtitle��6   5      5      �� 5   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0 10 0 0q�6;   .+�5      �� $��Movie��6     	TabButton#��[ 6%     AppColor#��[ 6H   �� 5      -   5        $��Episode��5      #��[ 6Q   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ ItemsDataGrid��5!        DataGridStyle1#��[ 6Q     DataGridCellStyle1   	CellStyle# [ 6y     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 6�     DataGridRowStyle1   RowStyle# [ 6�   $��4��6  ��6*   �� *MovieSubtitles+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Movie Name��6%   
   
IsReadOnly$

 True��6X      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
Movie.Name+6j     5$      $	 Language��6%   $

 True��6T   $
 auto 6f    67   �� *
Language+6f     5%      $	 Subtitle Path��6%   $

 True��6]   $
 auto 6o    6<   �� *SubtitlePath+6o   4  .System.Windows.Controls.DataGridTemplateColumn  5&      $	 
Operations��6)   $

 True��6=   $
 auto 6O      CellTemplate 5'      �� 5(      .R�5)      �� $ 
Horizontal=�6)   .+�5*   "   ��   GridEditButton#��[ 6)   ��6Q   ��  �� RelativeSource ��  �� AncestorType UserControl �� Mode$ FindAncestor=� �� Path$+ %DataContext.OpenEditDialogHostCommand���6�   ��  �� *Self+$ DataContext�.��5+   &   �� $��Center=�6u   ��65     $ PencilOutline=� 126u   5,   #   �� 5-   "     GridRemoveButton#��[ 6)   $��5 0 0 0q�6'  ��6S   ��  ��  UserControl$ FindAncestor=�$ DataContext.DeleteCommand���6�   ��  �� *Self+$ DataContext�.��5.   &   �� $��Center=�6u   ��65     $ DeleteOutline=� 126u   5/   #   50      52      54      56      57      58      