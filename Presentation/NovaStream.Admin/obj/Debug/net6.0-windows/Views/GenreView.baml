   M S B A M L   `   `   `  ����  NovaStream.Admin&     NovaStream.Admin.Views.GenreView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Genres��6   $��32(�6"   $��SemiBold"�60   $��0 20 0 0q�6F   $
��Left=�5      ���#1215186/   �� 5   
      	AddButton#��[  6   ��64   �� *OpenAddDialogHostCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6X   $��0 1 8 0q�6s   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size 116s   �� 5      $��Add New Genre��6   5      5      �� 5   
   $��1��6   $��1��6   ���#dae2ea$��	0 30 0 10q�6A   �� 5   
   $��2��6K   $��18(�6X   $��SemiBold"�6f   ���#121518$
��Left=�5   )   $��Center=�6D   ��5      �� *
GenreCount+ �� StringFormat$ 
{0} Genres��5   D   �� 5    
    & "MaterialDesignIconForegroundButton#��[ 6e   ���#121518$��80 0 0 0q�5!   )   $
��Left=�6;   $��Center=�6V   $��2��6q   ��5         $ Refresh=���6B   �� *RefreshCommand+5!   q   �� 5#   
   $��	Filter by��6   $��2��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�5$   )   $��Center=�6E   � 5&   
   $	��200��6   $��Right=�6   $��2��67   .+�5'      �� $
��15 0q�6   $��Center=�6&   ���#b0b9c6 J� IsHitTestVisible$ False��6V    K� ZIndex$ 1��5(      $��Search in Genres...��6)   y�5)      ��  �� ElementName$ 	txtSearch�� �� Path$ Text.IsEmpty�   BooleanToVisibilityConverter	 �� 	Converter#	 [ �� 5+      -   5        
 ��Name$
 	txtSearch��5+        TextboxFilter#��[ 6)   .��6P   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5,      +  %Microsoft.Xaml.Behaviors.EventTrigger  5-         	EventName$ TextChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5.      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SearchCommand+   CommandParameter 6R   �� $ 	txtSearch��$
 Text�5/      .��50   *   51      52      &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ ItemsDataGrid��54        DataGridStyle1#��[ 6I     DataGridCellStyle1   	CellStyle# [ 6q     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 6�     DataGridRowStyle1   RowStyle# [ 6�   $��3��6  ��6*   �� *Genres+   Columns 55      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly$
 True��6L      Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6^   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 63   �� *Name+6^   4  .System.Windows.Controls.DataGridTemplateColumn  59      $ 
Operations��6)   $
 True��6=   $
 auto	 6O      CellTemplate 5:      �� 5;      .R�5<      �� $ 
Horizontal=�6)   .+�5=   "   ��   GridEditButton#��[ 6)   ��6Q   ��  �� RelativeSource ��  �� AncestorType UserControl �� Mode$ FindAncestor=�$+ %DataContext.OpenEditDialogHostCommand���6�   ��  �� *Self+$ DataContext�.��5>   &   �� $��Center=�6u   ��65     $ PencilOutline=� 126u   5?   #   �� 5@   "    	 GridRemoveButton#��[	 6)   $��5 0 0 0q�6(  ��6S   ��  ��  UserControl$ FindAncestor=�$ DataContext.DeleteCommand���6�   ��  �� *Self+$ DataContext�.��5A   &   �� $��Center=�6u   ��65     $ DeleteOutline=� 126u   5B   #   5C      5D      5F      5I      5K      5L      