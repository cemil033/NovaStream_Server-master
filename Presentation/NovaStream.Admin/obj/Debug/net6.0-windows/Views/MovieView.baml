   M S B A M L   `   `   `  ����  NovaStream.Admin&     NovaStream.Admin.Views.MovieView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Movies��6   $��32(�6"   $��SemiBold"�60   $��0 20 0 0q�6F   $
��Left=�5      ���#1215186/   �� 5   
      	AddButton#��[  6   ��64   �� *OpenAddDialogHostCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6X   $��0 1 8 0q�6s   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size 116s   �� 5      $��Add New Movie��6   5      5      �� 5   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0 10 0 0q�6;   .+�5       �� $��Movies��6     	TabButton#��[ 6&     AppColor#��[ 6I   �� 5!      -   5        $��Actors��5!      ��5"      �� 5#       �� 
TargetType" ��6    �� BasedOn# [ 60    �� Triggers 5$      �� 5%       �� Binding 6*   ��  �� ElementName$ ItemsDataGrid��	 �� Path$	 SelectedItem�
 �� Value
 6k   Z� .a�5&   "   ��  �� Property � {� �� Value$ False��6>   5'      5)      5+      �� 5,      -   5        $��Genres��5,      ��5-      �� 5.      " ��6   # [ 60    5/      �� 50       6*   �� $ ItemsDataGrid��$	 SelectedItem�
 6k   Z� .a�51   "   ��  � {�$ False��6>   52      54      56      57      �� 59   
   $��3��6K   $��18(�6X   $��SemiBold"�6f   ���#121518$
��Left=�5:   )   $��Center=�6D   ��59      �� *
MovieCount+ �� StringFormat$ 
{0} Movies��5:   D   �� 5<   
    & "MaterialDesignIconForegroundButton#��[ 6e   ���#121518$��80 0 0 0q�5=   )   $
��Left=�6;   $��Center=�6V   $��3��6q   ��5<        $ Refresh=���6B   �� *RefreshCommand+5=   q   �� 5?   
   $��	Filter by��6   $��3��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�5@   )   $��Center=�6E   � 5B   
   $	��200��6   $��Right=�6   $��3��67   .+�5C      �� $
��15 0q�6   $��Center=�6&   ���#b0b9c6 J� IsHitTestVisible$ False��6V    K� ZIndex$ 1��5D      $��Search in Movies...��6)   y�5E      �� $ 	txtSearch��$	 Text.IsEmpty�   BooleanToVisibilityConverter �� 	Converter# [ �� 5G      -   5         ��Name$ 	txtSearch��5G        TextboxFilter#��[ 6)   .��6P   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5H      +  %Microsoft.Xaml.Behaviors.EventTrigger  5I         	EventName$ TextChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5J      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SearchCommand+   CommandParameter 6R   �� $ 	txtSearch��$
	 Text�5K      .��5L   *   5M      5N      &   System.Windows.Controls.DataGrid  5P   
   -   5          Name$ ItemsDataGrid��5P        DataGridStyle1#��[ 6I     DataGridCellStyle1   	CellStyle# [ 6q     DataGridColumnHeaderStyle1   ColumnHeaderStyle# [ 6�    	 DataGridRowStyle1   RowStyle# [	 6�   $��4��6  ��6*   �� *Movies+   Columns 5Q      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly$
 True��6L      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 6^   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 63   �� *Name+6^     5T      $ Director Fullname��6%   $
 True��6@   $
 auto	 6R    5U      `� 5V      $ {0} {1}��6'   .1�5W      �� $	 Director.Name�6&   �� 5X      $	 Director.Surname�6&   5Y      5[        5\      $
 Year��6%   $
 True��6L   $
 auto	 6^    63   �� *Year+6^     5]      $	 Age��6%   $
 True��6_   $
 auto	 6q    62   �� *Age+$
 {0}+��6q     5^      $ Description��6%   $
 True��6Z   $ *	 6l    6:   �� *Description+6l   4  .System.Windows.Controls.DataGridTemplateColumn  5`      $ 
Operations��6)   $
 True��6=   $
 auto	 6O       CellTemplate  5a      �� 5b      .R�5c      �� $ 
Horizontal=�6)   .+�5d   "   ��  
 GridEditButton#��[
 6)   ��6Q   �� ! �� RelativeSource! �� " �� AncestorType" UserControl# �� Mode$# FindAncestor=�$+	 %DataContext.OpenEditDialogHostCommand���6�   �� ! �� *Self+$	 DataContext�.��5e   &   �� $��Center=�6u   ��65     $ PencilOutline=� 126u   5f   #   �� 5g   "     GridRemoveButton#��[ 6)   $��5 0 0 0q�6'  ��6S   �� ! �� " UserControl$# FindAncestor=�$	 DataContext.DeleteCommand���6�   �� ! �� *Self+$	 DataContext�.��5h   &   �� $��Center=�6u   ��65     $ DeleteOutline=� 126u   5i   #   5j      5k      5m      5p      5r      5t      