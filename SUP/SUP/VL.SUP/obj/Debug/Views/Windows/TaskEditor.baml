   M S B A M L   `   `   `  ����>  :SUP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SUP.Views.WindowsSUP.Views.Windows  5   	   "    SUP.Views.Windows.TaskEditor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SUP.Views.Windows     5   	     � WindowStartupLocation$  CenterScreen=�5   F   
������  � WindowStyle$
 None=�5   3    � AllowsTransparency .  � Title$ 
TaskEditor��5   	   $	��450��6   $	��400��6)    � Icon$ /Resource/icon.png��65   .��5	      �� -   5        
������� �� CornerRadius$ 5��5	       $��5q�61   
���  ��._�5
   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      �� 5      �� 5      �� 5      $��50 �6    .+�5      �� -   5         ��Name$ closeButton��5      $��0��6*   $	��Top=�67   $��Right=�6O   $��X��6k      CloseTemplate#��[  6w   $
��10 5q�6�   $��3q�6�   6�   �� 5      $2��,Редактор задачи проекта��6   $��0��67   $��8q�6D   $��20(�6O   $
��Bold"�6]   $��Center=�6o   �� 5      $��1��6   $
��20px(�6&   .+�5      �� $#��Название задачи��6   $��Center=�63   �� 5      -   5         ��Name$ titleBox��5      $��Center=�6C   $��20px 5pxq�6g   ��6,   �� *Title+6g   5      �� 5      $��2��6   $
��20px(�6&   .+�5      �� $��Описание��6   $��Center=�6,   �� 5      -   5        $ descriptionTask��5      $��Center=�6P   $��20px 5pxq�6t   ��63   �� *Description+6t   5      �� 5       $��3��6   $
��20px(�6&   .+�5!      �� $��Исполнитель��6   $��Center=�6/   �� 5"      -   5        	 ��Name$	 performerBox��5"      $��20px 5pxq�61   $��Center=�6C   
 �� SelectedItem
 6g   �� *	Performer+��5#      �� 5$      .R�5%      ��  �� Orientation$ 
Horizontal=�6)   .+�5&   "   �� ��6(   �� *
FullName+5'      5(      5*      5+      �� 5-      $��4��6   $
��20px(�6&   .+�5.      �� $��Тестировщик��6   $��Center=�6/   �� 5/      -   5        $	 	testerBox��5/      $��20px 5pxq�6.   $��Center=�6@   
 6d   �� *Tester+��50      �� 51      .R�52      �� $ 
Horizontal=�6)   .+�53   "   �� ��6(   �� *
FullName+54      55      57      58      � 59      $��5��6   $��Center=�6%   $��Center=�6B   .+�5:      �� -   5        $ 
saveButton��5:      $��Сохранить��6-   $��5q�6Z     
MainButton#��[ 6e   �� 5;      -   5        $ deleteButton��5;      $��Удалить��6/   $��5q�6\   #��[ 6g   
���  ��6�   5<      5=      5>      5?      