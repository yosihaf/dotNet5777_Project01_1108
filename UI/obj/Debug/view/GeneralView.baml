   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.4.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      = 9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View 5         UI.View.GeneralView   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &viewclr-namespace:UI.View     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� 
�������$��1q�6$   $	��8pxq�68    �� Padding$	 8pxq�6E   ._�5   
   � $	��8pxq�6   $��0��6     5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    .+�5#      ��  
  Header#��[  6   .��64   General Data:6C   �� 5$      $��0��6   $��1��6$   .��61   Contracts Count:6C   �� 5%      $��1��6   $��1��6)    �� Orientation$ Vertical=�66   .+�5&      ��   	textBlock#��[ 5'      ��5&      �� *ContractsCount+5(      5)      �� 5+      $��0��6   $��2��6$   .��61   Employees Count:6C   �� 5,      $��1��6   $��2��6)   $ Vertical=�66   .+�5-      �� #��[ 5.      ��5-      �� *EmployeesCount+5/      50      �� 52      $��0��6   $��3��6$   .��61   Employers Count:6C   �� 53      $��1��6   $��3��6)   $ Vertical=�66   .+�54      �� #��[ 55      ��54      �� *EmployersCount+56      57      �� 59      $��0��6   $��4��6$   .��61   Speciailization Count:6I   �� 5:      $��1��6   $��4��6)   $ Vertical=�66   .+�5;      �� #��[ 5<      ��5;      �� *SpeciailizationCount+5=      5>      5@      5A      �� 5B   
   $	��8pxq�6   $	 8pxq�6   
�������$��1��6?   $��1q�6O   ._�5C      �� $ Vertical=�6   .+�5D      �� #��[  6   .��68   Last Year Benefits:6M   &   System.Windows.Controls.DataGrid  5E      -   5        $��
MyDataGrid��5E      $��1��5F      $��8q�5H      $��Center=�5I      $��Stretch=�5J      $��Stretch=�5K         SelectionMode$ Extended=�5L         
IsReadOnly .    AutoGenerateColumns .  ��5G      �� *LastYearBenefits+   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6)   	   Header$	 Month��6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *Name+6N     5R      $	 200 6)   $	 B��6Q   
 65   �� *	Benefit+6Q   5T      5U      5V      5W      5X      