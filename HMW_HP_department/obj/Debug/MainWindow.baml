   M S B A M L   `   `   `  ����L  HHMW_HP_department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HMW_HP_departmentHMW_HP_department  5   	   "    HMW_HP_department.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HMW_HP_department     5   	     � Title$  
MainWindow��5   	   $	��490��6   $	��550��6)   
������.��5	      ]� .+�5
   
   �� $	��Top=�6   $��Center=�6%   $��20(�6B   $��10q�6P   
������.��6t   !HR department management system6�   �� 5   
   -   5        $��
Add worker��5      $��10q�6;   $��5q�6G   $��Bottom=�6S   
�������$��Center=�6�   $��24(�6�   
������6�   � 5   
    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $��0��6!   $��Workers selection��61   .��5      ]� .+�5      �� $	��Top=�6   .��6-   Company departments:6C   �� 5      -   5         ��Name$ list1��5      $	��Top=�6*    �� DisplayMemberPath$ @name��6?    �� SelectedIndex$ 0��5      ��5      ��    	provider1 �� Source# [   �� XPath$ 
department��5   /   �� 5      $	��Top=�6   .��6-   Company workers:6?   �� 5      -   5         ��Name$ list2��5      ��5      �� 5      .R�5   "   �� �� 5   "   �6&   �� $ @name�� �� 5   "   �6&   �� $ @middlename��5   #   5      5!      5"      5#      �� 5$      $��0��6   $��1��6%   $��Personal data��65    � DataContext 6L   �� 	 �� ElementName$	 list2��
 �� Path$
 SelectedItem�.��5%      �  5&      �� 5'      $
��1.5* �6'   �� 5(      $��* �6'   .+�5*      �� $��0��6   $��0��6)   ��69   �� $ @photo���� 5+      $��0��6!   $��1��6.   $��Center=�6>   .+�5,      �� .��6   
Surname:6&   �� 5-      ��6   �� $ @surname���� 5.      .��6   Name:6#   �� 5/      ��6   �� $ @name���� 50      .��6   Middlename:6)   �� 51      ��6   �� $ @middlename���� 52      .��6   
Birthdate:6(   �� 53      ��6   �� $ 
@birthdate���� 54      .��6   Specialization:6-   �� 55      ��6   �� $ @specialization���� 56      .��6   	Position:6'   �� 57      ��6   �� $ 	@position���� 58      .��6   Department:6)   �� 59      ��6   �� $ @dname��5:      5;      5<      5=      5>      5?      