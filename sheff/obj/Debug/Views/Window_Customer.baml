   M S B A M L   `   `   `  ����@  <sheff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:sheff.Viewssheff.Views  5      !    sheff.Views.Window_Customer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      +localclr-namespace:sheff.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6+     � Title$1  +Шеф-Построит! - Заказчик��5	      $	��620��5
      $	��800��6    � WindowStartupLocation$ CenterScreen=�5      
����p�� � 	Resources 5       �� 
TargetType �� Property �� Value   YourImageBrushKey �� ImageSource �� Opacity j� Stretch��%  '��       '�� J     &	  �     �� 5   
   " ��6   .�5      ��  � ��
 � ���6+   5      �� 5   
   " ��6   .�5      ��  � ��
 � ���6+   5      �� 5   
   $ \Images\fon_customer.png��6/   $	 0.8Q�6V   $ UniformToFill=�6d   5      .��5      ]� .+�5   
   �� $
��Auto��6   .@�5      �� $
��Auto��6   ��5      �� 5      	 �� Orientation$	 
Horizontal=�6!   .+�5       �� $��\Icons\MenuIcon.png��6    $��20��6=   $��20��6H   $��0,0,10,0q�6T   �� 5!      $��Главная��6$   5"      .��5$      � .+�5%      �� #��[  6   5'      5(      5*      �� 5-      $
��Auto��6   ��5.      �� 5/      $	 
Horizontal=�6!   .+�50      �� $��\Icons\OrderIcon.png��6    $��20��6>   $��20��6I   $��0,0,10,0q�6U   �� 51      $��Сделать заказ��6$   52      .��55      � .+�56      �� $��Сделать заказ��6    $��110,10,30,50q�65   57      58      �� 5;      $
��Auto��6   ��5<      �� 5=      $	 
Horizontal=�6!   .+�5>      �� $��\Icons\ProfileIcon.png��6    $��20��6@   $��20��6K   $��0,0,10,0q�6W   �� 5?      $��Профиль��6$   5@      .��5B      �� #��[  6   ._�5C      � 
 � ColumnDefinitions
 5D      �� 5E      $��2* �6/   �� 5F      $��2* �6/   �� 5G      $��2* �6/   .+�5J      #  MaterialDesignThemes.Wpf.Card  $��1��6.   $
��Auto��6>   $��Stretch=�6K   .��5K      �  � RowDefinitions 5L      �� 5M   "   $	��140 �60   �� 5N   "   $��* �60   �� 5O   "   $
��Auto �60   �� 5P   "   $
��Auto �60   �� 5Q   "   $
��Auto �60   �� 5R   "   $
��Auto �60   .+�5U      �� $	��140��5V       $��Resources/Contact.png��5W       $��UniformToFill=�5X       �� 5Z      $��0��5[       $��
0,0,16,-20q�5\       $��Right=�5]       $��Bottom=�5^        0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5_       .��5a   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ShareVariant=�6:   5b      �� 5c      $��1��5d       $��8,24,8,4q�5e       .+�5f   "   �� $��0q�5g       $  MaterialDesignSubtitle1TextBlock#��[ 5h      $ ��E.T. the Extra-Terrestrial��5i      (� 5k   "   $��16��5l      $��0,4,0,8q�5m      $
��Left=�5n      .��5p   &   (  "MaterialDesignThemes.Wpf.RatingBar  $��0q�5q   !   
��� ���   Orientation$ 
Horizontal=�5s   !      Value$ 3Q�5t   !   5u   #   �� 5w   "   $��Center=�5x         MaterialDesignBody1TextBlock#��[ 5y      $L��FТут надо данные о пользователе. БЛоком��5z      $
��Wrap=�5{      5}      �� 5      $��2��5�      $��8,0,8,0q�5�        MaterialDesignDarkSeparator#��[ 5�      �� 5�      $��3��5�      $��8,4,8,4q�5�         MaterialDesignBody2TextBlock#��[ 5�      $��Tonight's availability��5�      � 5�      $��4��6#   
 5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   .+�5�   "   �� $��1��5�      $��4,8,8,4q�5�       �� SelectedIndex$ 0��5�       ' #MaterialDesignToolToggleFlatListBox#��[ 5�       5�   &    ' #MaterialDesignToolToggleListBoxItem �� BasedOn��%d   '��       7  �� 5�   *   " ��5�   (   8   .�5�   .   ��  � ��$ 4,6,4,6q�6H   5�   +   5�   '    � ToolTip 5�   &   �� 5�   *   .+�5�   .   �� $%��MaterialDesignFlatToggleListBox��68   �� 5�   .   $��Exclusive selection��68   �� 5�   .   $A��;ListBoxAssist.IsToggle allows more natural toggle behaviour��68   5�   +   .@�5�   &   �� .��5�   *   �� $��18:00��64   5�   '   �� 5�   &   .��5�   *   �� $��19:00��64   5�   '   �� 5�   &   .��5�   *   �� $��22:00��64   5�   '   5�   #   5�      �� 5�   "   $��5��6-   .+�5�   &   �� $��
Выход��6-     MaterialDesignFlatButton#��[ 6n   ��6=   �� *ExitFromAccauntCommandommand+6n   5�      5�      5�      5�      5�      5�      �� 5�      $
��Auto��6   ��5�      �� 5�      $	 
Horizontal=�6!   .+�5�      �� $��\Icons\InProgresIcon.png��6    $��20��6B   $��20��6M   $��0,0,10,0q�6Y   �� 5�      $��В процессе��6$   5�      .��5�      � .+�5�      �� $��В процессе��6    $��110,10,30,50q�62   5�      5�      �� 5�      $
��Auto��6   ��5�      �� 5�      $	 
Horizontal=�6!   .+�5�      �� $��\Icons\HistoryIcon.png��6    $��20��6@   $��20��6K   $��0,0,10,0q�6W   �� 5�      $��История��6$   5�      .��5�      � .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ HistoryGrid_Customer��5�   <      AutoGenerateColumns .  ��6Z   �� *OrdersForHistories+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6S     5�      $ Описание��6Q   $ 70 6c    61   �� *Description+6c   5�      �� 5�      $��Button��6   $
��Left=�6.   $��
693,56,0,0q�5�      $	��Top=�61   $	��107��6I   ��5�   I   �� *HistoryCommand+5�   I   5�      5�      5�      5�      5�      