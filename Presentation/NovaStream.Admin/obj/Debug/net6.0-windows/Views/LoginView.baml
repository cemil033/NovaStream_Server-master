   M S B A M L   `   `   `  ����  NovaStream.Admin&     NovaStream.Admin.Views.LoginView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��6   
������  � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ /Views/logo.ico��6.   $	��500��6E   $	��800��6R    � 	Resources 5
         	titleText �� 
TargetType �� Property �� Value  
normalText  imgClose �� Triggers	 P� Property
 P� Value �� ScaleX �� ScaleY  InputPasswordBox % !MaterialDesignOutlinedPasswordBox �� BasedOn.  (MaterialDesignThemes.Wpf.TextFieldAssist  AppColor)  #MaterialDesignThemes.Wpf.HintAssist/  )MaterialDesignThemes.Wpf.ValidationAssist  ForegroundAppColor��%�  &	        &	 �     &	 �    &	 �    7  7  7  7  �� 5   
   " ��6"   .�5      ��  � ��$ 36(�6)   66   �� 5       � ��$
 Bold"�6+   6:   �� 5       �@��TextAlignment$ Center=�6.   6?   �� 5       � �� �#fff6:   5      �� 5   
   " ��6#   .�5      ��  � ��$ 16(�6)   66   �� 5       �@��
LineHeight$ 28��6+   68   �� 5       � ��$
 Wrap=�6-   6<   �� 5       �@��TextAlignment$ Center=�6.   6?   �� 5       � �� �#fff6:   5      �� 5   
   " ��6!   .�5      ��  � ��$ 15��6&   63   �� 5       � ��$ 15��6'   64   �� 5       � ��$	 Top=�62   6@   �� 5       � ��$ Right=�64   6D   �� 5        �@�Cursor$
 Hand��6'   �� 5!       � ��$ 	0 13 13 0q�6'   6;    5#      P� 5$      	 �@J�IsMouseOver$

 True��61   . �5%      ��  � z� 5&      �� 5'      $	 1.1Q�6-   $	 1.1Q�6:   5)      5*      5,      �� 5.   
   " G�6)   8   .�5/      ��  �@ UnderlineBrush8  6N   �� 50       �@ 
Foreground8  6E   �� 51       �@ FloatingScale$	 1.1Q�6H   �� 52       �@ OnlyShowOnFocus$
 True��6P   �� 53       �@ UsePopup$
 True��6I   �� 54       �@ 
Background
 ���� 6K    56      P� 57      	 �@ 
IsFloating$

 True��6J   . �58      ��  �@ 
Background8  6M   59      5;      5=      .��5?      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ LoginMessageBox��6    .��5@   
   �  � ColumnDefinitions 5B      �� 5C      $��* �6#   �� 5D      $
��1.5* �6#   .+�5G      �� -   5         K� ZIndex$ 1��5G   j   $��1��6{   #��[ 6�   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�6�   �� 5I      #��[ 6    �� CornerRadius$ 	10 0 0 10��6<   ._�5J      �� $��Center=�6   .+�5K      �� 
�������$ 30��65   $	��160��6G   $	��160��6S   $��0 0 0 40q�6`   ._�5L      �� $��Center=�6a   $��Center=�6|   #��[ 6�   ��6)     $
 User=�   Size 1306�   5M      �� 5O      $��Welcome Back!��6     �� TextAlignment$ Center=�65   $��SemiBold"�6L   $��28(�6b   #��[ 6p   6�   �� 5P      $
��Wrap=�6    $��16(�64   $ Center=�6B   #��[ 6Y   $��20 20q�6�   $<��6To keep connected with us please login with admin user��6�   6�   5Q      5R      �� 5T      -   5        ���#fff$ 	0 10 10 0��5T   '   $��1��6a   ._�5U      �� $��Center=�6   .+�5V      �� $��Sign in to App��6    #��[ 66   $��0 0 0 5q�6]   #��[  6n   �� 5X      #��[ 6    ���#878787$��	0 10 0 10q�6Y   �� 5Y      $$�Enter your email and password ��6    �� 5Z      .�6   
to sign in6+   5[      �� 5]         Hint$ Email��6Z   $��50, 10q�6�     InputTextBox#��[ 6�   ��6   �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�6�   G� 5^      -   5        $ Password��5^   S   $��50, 10q�6}   #��[ 6�   �� 5`      $��Sign In��6   $��Center=�6Q   $��40��6n   $	��300��6z   $��0 20 0 0q�6�     	AddButton#��[ 6�   ��6/   �� *SignInCommand+6�   5a      5b      5d      5e      5g      