   M S B A M L   `   `   `  ����  NovaStream.Admin0    *NovaStream.Admin.Views.EpisodeSubtitleView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   
   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   
   :d2http://schemas.microsoft.com/expression/blend/2008  5   
   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Episode Subtitles��6   $��32(�6-   $��SemiBold"�6;   $��0 20 0 0q�6Q   $
��Left=�5      ���#1215186+   �� 5   
      	AddButton#��[  6   ��64   �� *OpenAddDialogHostCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6X   $��0 1 8 0q�6s   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size 116s   �� 5      $��Add New Episode Subtitle��6   5      5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0 10 0 0q�6;   .+�5      �� -   5        $��Movie��5        	TabButton#��[ 6M   �� 5      $��Episode��6   #��[ 6'     AppColor#��[ 6J   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ ItemsDataGrid��5         DataGridStyle1#��[ 6S     DataGridCellStyle1   	CellStyle# [ 6{     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 6�     DataGridRowStyle1   RowStyle# [ 6�   $��4��6  ��6*   �� *EpisodeSubtitles+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Episode Name��6%   
   
IsReadOnly$

 True��6\      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Episode.Name+6n     5#      $	 Language��6%   $

 True��6T   $
 auto 6f    67   �� *
Language+6f     5$      $	 Subtitle Path��6%   $

 True��6]   $
 auto 6o    6<   �� *SubtitlePath+6o   4  .System.Windows.Controls.DataGridTemplateColumn  5&      $	 
Operations��6)   $

 True��6=   $
 auto 6O      CellTemplate 5'      �� 5(      .R�5)      ��   GridRemoveButton#��[ 6%   $��5 0 0 0q�6$  ��6O   ��  �� RelativeSource ��  �� AncestorType UserControl �� Mode$ FindAncestor=� �� Path$ DataContext.DeleteCommand���6�   ��  �� *Self+$ DataContext�.��5*   "   �� $��Center=�6q   ��61     $ DeleteOutline=� 126q   5+      5,      5.      51      53      55      