   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5          UI.View.EmployeesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &Viewclr-namespace:UI.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
      UI.View.HeaderListView  $
��50px��6      
AddCommand 6,   �� *
AddCommand+   SearchCommand 6N   �� *SearchCommand+�� 5   
   $��1��6   
���  ����6.   �� *	Message+6L   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
MyDataGrid��5      $��2��5      $��8q�5      $��Center=�5      $��Stretch=�5      $��Stretch=�5         SelectionMode$ Extended=�5         
IsReadOnly .    AutoGenerateColumns .  ��5      �� *
Collection+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Name��6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6&   �� *Name+6?     5      $ ID��6=    6&   �� *ID+6=     5      $
 Phon��6?    6&   �� *Phon+6?     5       $ Specialization��6M    6&   �� *SpecializationName+6M   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $ Options��6)   	   CellTemplate	 5"      �� 5#      .R�5$      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5%   "   ��    MetroCircleButtonStyle#��[  6)   $
��40px��5&   )   $
��40px��5'   )   ��5(   )   �� *ID+��5)   )   ��  �� RelativeSource ��  �� AncestorType$ UserControlL� �� Path$ DataContext.RemoveCommand���5*   &   �� 5+   *   $��20��64   $��20��6?   ��5,   .   !� 5-   2     appbar_close !� Visual# [ 6>    j� Stretch$
 None=�6e   5/   +   51   #   �� 52   "   #��[  6)   $
��40px��53   )   $
��40px��54   )   ��55   )   �� *ID+��56   )   ��  �� $ UserControlL�$ DataContext.EditCommand���57   &   �� 58   *   $��30��64   $��30��6?   ��59   .   !� 5:   2     appbar_edit# [ 6>   $
 None=�6d   5<   +   5>   #   �� 5?   "   #��[  6)   $
��40px��5@   )   $
��40px��5A   )   ��5B   )   �� *ID+��5C   )   ��  �� $ UserControlL�$ DataContext.ViewCommand���5D   &   �� 5E   *   $��20��64   $��20��6?   ��5F   .   !� 5G   2     
appbar_eye# [ 6>   $
 None=�6c   5I   +   5K   #   5M      5N      5P      5R      ]� 5T   
   -   5        $��ContentContract��5T      $��2��6,   $��0��5W      ���	#B2000000y�5U      �� *
IsShowItem+  BoolToVisibility �� 	Converter# [ .+�5Y      �� $	��8pxq�6   $��Bottom=�6&   $
 
Horizontal=�6>   $��RightToLeft=�6W   .+�5Z      �� $	��8pxq�6   $��100px��6&     AccentedSquareButtonStyle#��[ 64   y�5[      �� *Mode+  ViewModeToVisablity# [   Add �� ConverterParameter# [ ��5^      �� *SaveCommand+.��69   Save6?   �� 5_      $	��8pxq�6   $��100px��6&   #��[ 64   y�5`      �� *Mode+# [   Edit# [ ��5c      �� *UpdateCommand+.��6;   Update6C   �� 5d      $	��8pxq�6   $��100px��6&    	 SquareButtonStyle#��� 	 64   ��5e      �� *CloseCommand+.��6:   Close6A   5f         UI.View.EmployeeView  5g      -   5          Name$ contractView��5g   >   $��500px��6    $��0,40pxq�6.   
������� � DataContext 6i   �� *SelectedItemVM+5h      5i      5j      