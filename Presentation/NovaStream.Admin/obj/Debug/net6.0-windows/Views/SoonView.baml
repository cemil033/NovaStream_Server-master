   M S B A M L   `   `   `  ����  NovaStream.Admin%    NovaStream.Admin.Views.SoonView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Soons��6   $��32(�6!   $��SemiBold"�6/   $��0 20 0 0q�6E   $
��Left=�5      ���#1215186/   �� 5   
      	AddButton#��[  6   ��64   �� *OpenAddDialogHostCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6X   $��0 1 8 0q�6s   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size 116s   �� 5      $��Add New Soon��6   5      5      �� 5   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0 10 0 0q�6;   .+�5       �� $��Soons��6     	TabButton#��[ 6%     AppColor#��[ 6H   �� 5!      -   5        $��Genres��5!      ��5"      �� 5#       �� 
TargetType" ��6    �� BasedOn# [ 60    �� Triggers 5$      �� 5%       �� Binding 6*   ��  �� ElementName$ ItemsDataGrid��	 �� Path$	 SelectedItem�
 �� Value
 6k   Z� .a�5&   "   ��  �� Property � {� �� Value$ False��6>   5'      5)      5+      5,      �� 5.   
   $��3��6I   $��18(�6V   $��SemiBold"�6d   ���#121518$
��Left=�5/   )   $��Center=�6D   ��5.      �� *	SoonCount+ �� StringFormat$ 	{0} Soons��5/   D   �� 51   
    & "MaterialDesignIconForegroundButton#��[ 6e   ���#121518$��80 0 0 0q�52   )   $
��Left=�6;   $��Center=�6V   $��3��6q   ��51        $ Refresh=���6B   �� *RefreshCommand+52   q   �� 54   
   $��	Filter by��6   $��3��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�55   )   $��Center=�6E   � 57   
   $	��200��6   $��Right=�6   $��3��67   .+�58      �� $
��15 0q�6   $��Center=�6&   ���#b0b9c6 J� IsHitTestVisible$ False��6V    K� ZIndex$ 1��59      $��Search in Soons...��6)   y�5:      �� $ 	txtSearch��$	 Text.IsEmpty�   BooleanToVisibilityConverter �� 	Converter# [ �� 5<      -   5         ��Name$ 	txtSearch��5<        TextboxFilter#��[ 6)   .��6P   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5=      +  %Microsoft.Xaml.Behaviors.EventTrigger  5>         	EventName$ TextChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5?      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SearchCommand+   CommandParameter 6R   �� $ 	txtSearch��$
	 Text�5@      .��5A   *   5B      5C      &   System.Windows.Controls.DataGrid  5E   
   -   5          Name$ ItemsDataGrid��5E        DataGridStyle1#��[ 6H     DataGridCellStyle1   	CellStyle# [ 6p     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 6�    	 DataGridRowStyle1   RowStyle# [	 6�   $��4��6  ��6*   �� *Soons+   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly$
 True��6L      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 6^   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 63   �� *Name+6^     5I      $ OutDate��6%   $
 True��6b   $
 auto	 6t    66   �� *	OutDate+$ d��6t     5J      $ Description��6%   $
 True��6Z   $ *	 6l    6:   �� *Description+6l   4  .System.Windows.Controls.DataGridTemplateColumn  5L      $ 
Operations��6)   $
 True��6=   $
 auto	 6O       CellTemplate  5M      �� 5N      .R�5O      �� $ 
Horizontal=�6)   .+�5P   "   ��  
 GridEditButton#��[
 6)   ��6Q   �� ! �� RelativeSource! �� " �� AncestorType" UserControl# �� Mode$# FindAncestor=�$+	 %DataContext.OpenEditDialogHostCommand���6�   �� ! �� *Self+$	 DataContext�.��5Q   &   �� $��Center=�6u   ��65     $ PencilOutline=� 126u   5R   #   �� 5S   "     GridRemoveButton#��[ 6)   $��5 0 0 0q�6'  ��6S   �� ! �� " UserControl$# FindAncestor=�$	 DataContext.DeleteCommand���6�   �� ! �� *Self+$	 DataContext�.��5T   &   �� $��Center=�6u   ��65     $ DeleteOutline=� 126u   5U   #   5V      5W      5Y      5\      5^      5`      