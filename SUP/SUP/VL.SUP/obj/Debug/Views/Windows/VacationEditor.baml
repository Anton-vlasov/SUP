   M S B A M L   `   `   `  ����>  :SUP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SUP.Views.WindowsSUP.Views.Windows  5   	   &     SUP.Views.Windows.VacationEditor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SUP.Views.Windows     5   	   -   5          �Name$  vacationEditor��5   	   
������  � WindowStyle$
 None=�5   P    � AllowsTransparency .  � WindowStartupLocation$ CenterOwner=�5       � Title$ VacationEditor��5	   	   $	��450��6    $	��400��6-    � Icon$ /Resource/icon.png��69   .��5
      �� -   5        
������� �� CornerRadius$ 5��5
       $��5q�61   
���  ��._�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      �� 5      �� 5      �� 5      $��50 �6    .+�5      �� -   5         ��Name$ closeButton��5      $��0��6*   $	��Top=�67   $��Right=�6O   $��X��6k      CloseTemplate#��[  6w   $
��10 5q�6�   $��3q�6�   6�   �� 5      $-��'Привязка сотрудников��6   $��0��64   $��8q�6A   $��20(�6L   $
��Bold"�6Z   $��Center=�6l   �� 5      $��1��6   $
��20px(�6&   .+�5      �� $��Дата начала��6   $��Center=�6/   (  "System.Windows.Controls.DatePicker  5      -   5        	  Name$	 startDateBox��5      $��20px 5pxq�6V   $��Center=�6h   
   SelectedDate
 63   �� *	DateStart+6�   5      �� 5      $��2��6   $
��20px(�6&   .+�5      �� $!��Дата окончания��6   $��Center=�62     5      -   5        $	 
endDateBox��5         SelectedDateFormat$ Short=�6R   $��20px 5pxq�6m   $��Center=�6   
 61   �� *	DateEnd+6�   5      �� 5!      $��3��6   $
��20px(�6&   .+�5"      �� $��Комментарий��6   $��Center=�6/   �� 5#      -   5         ��Name$ SecondNameBox��5#      $��20px 5pxq�6J   $��Center=�6\   ��61   �� *	Comment+6\   5$      �� 5&      $��4��6   $
��20px(�6&   .+�5'      �� $��Сотрудник��6   $��Center=�6-   �� 5(      -   5         ��Name$ employeeBox��5(      $��20px 5pxq�60   $��Center=�6B   ��5)      �� 5*      .R�5+      ��  �� Orientation$ 
Horizontal=�6)   .+�5,   "   �� ��6(   �� *
FullName+5-      5.      50      51      � 52      $��5��6   $��Center=�6%   $��Center=�6B   .+�53      �� -   5        $ 
saveButton��53      $��Сохранить��6-   $��5q�6Z     
MainButton#��[ 6e   �� 54      -	   5        $ deleteButton��54      $��Удалить��6/   $��5q�6\   #��[ 6g   
���  ��6�   55      56      57      58      