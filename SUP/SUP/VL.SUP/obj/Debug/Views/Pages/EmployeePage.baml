   M S B A M L   `   `   `  ����>  :SUP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SUP.Views	SUP.Views  5          SUP.Views.EmployeesPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:SUP.Views     5        N� Title$  EmployeePage��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��200px �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ mainList��5      $��0q�6%   $��Hidden=�69   $��4��6m      	MainColor#��[  6~   ��5      �� 5      .R�5      A�  A� Columns$ 2��6"   5      ��5      �� 5      .R�5      �� $	��244��6!   .+�5      �� $��3q�6!   ��5       �� 5!   "    �� 
TargetType" ��6(    �� Triggers 5"   &   �� 5#   *    �� Binding 66   �� *Border+ �� Value True6Q   .a�5$   .   �� 	 �� Property	 � ��
 �� Value

 ����6L   5%   +   5'   #   5)      �� 5*      $��5q�6>   $��55��6I   $��Center=�6U   $��Center=�6p   $
��Bold"�6�   $��20(�6�   $
��Wrap=�6�    �� TextAlignment$ Center=�6�   ��6$   �� *
FullName+6�   �� 5+      $��5q�6H   $��16(�6S   $
��Wrap=�6a   $ Center=�6u   ��6$   �� *EmployeeTypeString+6u   �� 5,      $��16(�6<   $��5q�6J   $
��Wrap=�6U   $ Center=�6i   ��6$   �� *Salary+6i   �� 5-      $��5q�6H   $��16(�6S   $
��Wrap=�6a   $ Center=�6u   ��6$   �� *PerformerTaskCount+6u   �� 5.      $��5q�6E   $��16(�6P   $
��Wrap=�6^   $ Center=�6r   ��6$   �� *TesterTaskCount+6r   �� 5/      $��5q�6C   $��16(�6N   $
��Wrap=�6\   $ Center=�6p   ��6$   �� *ProjectsCount+6p   50      52      54      �� 56   
   -   5         ��Name$ 	addButton��56      $��0��6$   $��1��61     
MainButton#��[ 6A   
������$+��%Добавить сотрудника��6�   $��Stretch=�6�   $��5q�6�   6�   �� 57   
   -   5        $ vacationsButton��57      $��1��6*   $��2��67   #��[ 6G   
������$+��%Отпуска сотрудников��6�   $��Stretch=�6�   $��5q�6�   6�   �� 59   
   $��3��6   $��2��6%   $��Center=�62   $��16(�6M   .+�5:      �� $��Должности��6   $ Center=�6)   �� 5;      -   5         ��Name$ employeeTypeBox��5;      $��5q�60    �� DisplayMemberPath$ Title��6;   $��Center=�6U    �� SelectedValuePath$ Id��6y   6�   5<      �� 5>   
   $��3��6   $��3��6%   $��Center=�62   $��16(�6M   .+�5?      �� $ ��Поиск по имени��6   $ Center=�6.   �� 5@      -   5         ��Name$ nameBox��5@      $��5q�6'   $��Center=�62   6V   5A      5B      5C      