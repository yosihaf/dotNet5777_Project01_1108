   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.4.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      = 9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View 5         UI.View.BankAccountView   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &viewclr-namespace:UI.View     5      .��5
   
   �   � ColumnDefinitions  5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5!   
   �� $��0��6   $��1��6    .��6-   
Bank Name:5"      �� 5#      $��2��6   $��1��6)    �� Orientation$ Vertical=�66   .+�5$      ��  �� DisplayMemberPath$
 Name��5%       	  input#��[  5&       �� SelectedValuePath$ Value��5'      ��5$      �� *BanksNamesDetails+ �� SelectedValue 5(      �� *
BankNumber+y�5)      �� *Mode+  ViewModeToVisablity �� 	Converter# [   	EditOrAdd �� ConverterParameter# [ 5-      �� 5.        	textBlock#��[ 5/      ��5.      �� *
BankName+y�50      �� *Mode+# [   View# [ 53      55      �� 5I   
   $��0��6   $��4��6    .��6-   Branch Number:5J      �� 5K      $��2��6   $��4��6)   $ Vertical=�66   .+�5L      �� #��[ 5M      ��5L      �� *BranchNumber+y�5N      �� *Mode+# [ # [ 5Q      �� 5R      #��[  5S      ��5R      �� *BranchNumber+y�5T      �� *Mode+# [ # [ 5W      �� 5X   
   $��0��6   $��5��6    .��6-   Number Account:5Y      �� 5Z   
   $��2��6   $��5��6%   $ Vertical=�62   .+�5[      �� #��[ 5\      ��5[      �� *NumberAccount+y�5]      �� *Mode+# [ # [ 5`      �� 5a      #��[  5b      ��5a      �� *NumberAccount+y�5c      �� *Mode+# [ # [ 5f      �� 5h      $��9��6   $��0��5i      $��3��5j       � IsSharedSizeScope . ��5k      �� *ValidetionMessages+��5m      �� 5n      .R�5o      �   5p      �� 5q   "   	 z� SharedSizeGroup$		 Key��63   �� 5r   "   $	  ��63   �� 5s   "   $	 messages��63   .+�5u      �� 
���  ��$��2q�6:   $��0��6Z   ��6E   �� *Key+6Z   �� 5v      
���  ��$��2q�6:   $��:��6E   $��1��6N   �� 5w      
���  ��$��2q�6:   $��2��6]   ��6F   �� *Value+6]   5x      5y      5{      5|      5}      