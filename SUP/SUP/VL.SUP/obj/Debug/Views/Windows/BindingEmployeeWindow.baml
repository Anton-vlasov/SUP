   M S B A M L   `   `   `  ����>  :SUP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SUP.Views.WindowsSUP.Views.Windows  5   	   -    'SUP.Views.Windows.BindingEmployeeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SUP.Views.Windows     5   	     � 
ResizeMode$  NoResize=�67    � WindowStartupLocation$ CenterScreen=�5      
������  � WindowStyle$
 None=�6X    � AllowsTransparency .  � Title$ BindingEmployeeWindow��5   	   $	��160��6'   $	��400��64    � Icon$ /Resource/icon.png��6@   .��5	      �� -   5        
������� �� CornerRadius$ 5��5	       $��5q�61   
���  ��._�5
   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      $��50 �6    .+�5      �� -   5         ��Name$ closeButton��5      $��0��6*   $	��Top=�67   $��Right=�6O   $��X��6k      CloseTemplate#��[  6w   $
��10 5q�6�   $��3q�6�   6�   �� 5      $-��'Привязка сотрудников��6   $��0��64   $��8q�6A   $��20(�6L   $
��Bold"�6Z   $��Center=�6l   �� 5      -   5        	 ��Name$	 employeeBox��5      $��30��6,   $��1��68   $��10q�6E   
 �� DisplayMemberPath$
 FullName��6�   $��Center=�6�   $��18(�6�   �� 5       �� Orientation$ 
Horizontal=�6   $��2��62   $��Center=�6?   $��0q�6\   .+�5      �� -   5        $ 	addButton��5      $*��$Привязать к проекту��6,     
MainButton#��[ 6b   
������6�   �� 5      -   5        $ removeButton��5      $y�	Collapsed=�6/   $*��$Отвязать от проекта��6F   $��5 0 0 0q�6d   #��[ 6u   
���  ��6�   5      5      5      5      