   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5          UI.View.ContractsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &Viewclr-namespace:UI.View     5      -   5          >�Name$  ContractsVieww��5      .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
      UI.View.HeaderListView  $
��50px��6      
AddCommand 6,   �� *
AddCommand+   SearchCommand 6N   �� *SearchCommand+�� 5   
   $��1��6   
���  ����6.   �� *	Message+6L   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
MyDataGrid��5      $��2��5      $��8q�5      $��Center=�5      $��Stretch=�5      $��Stretch=�5         SelectionMode$ Extended=�5         
IsReadOnly .    AutoGenerateColumns .  ��5      �� *
Collection+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Name��6G   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6&   �� *EmployeeName+6G     5      $ Employer Name��6G   	 6&   �� *EmployerName+6G     5       $ Specialization ��6G   	 6&   �� *EmployeeName+6G     5!      $ 	From Date��6C   	 6&   �� *
FromDate+6C     5"      $ To Date��6A   	 6&   �� *ToDate+6A     5#      $ ID��6=   	 6&   �� *ID+6=   4  .System.Windows.Controls.DataGridTemplateColumn  5$      $ Options��6)   
   CellTemplate
 5%      �� 5&      .R�5'      ��  �� Orientation$ 
Horizontal=�6)   .+�5(   "   ��    MetroCircleButtonStyle#��[  6)   $
��40px��5)   )   $
��40px��5*   )   ��5+   )   �� *ID+��5,   )   ��  �� RelativeSource ��  �� AncestorType$ UserControlL� �� Path$ DataContext.RemoveCommand���5-   &   �� 5.   *   $��20��64   $��20��6?   ��5/   .   !� 50   2     appbar_close !� Visual# [ 6>    j� Stretch$
 None=�6e   52   +   54   #   �� 55   "   #��[  6)   $
��40px��56   )   $
��40px��57   )   ��58   )   �� *ID+��59   )   ��  �� $ UserControlL�$ DataContext.EditCommand���5:   &   �� 5;   *   $��30��64   $��30��6?   ��5<   .   !� 5=   2     appbar_edit# [ 6>   $
 None=�6d   5?   +   5A   #   �� 5B   "   #��[  6)   $
��40px��5C   )   $
��40px��5D   )   ��5E   )   �� *ID+��5F   )   ��  �� $ UserControlL�$ DataContext.ViewCommand���5G   &   �� 5H   *   $��20��64   $��20��6?   ��5I   .   !� 5J   2     
appbar_eye# [ 6>   $
 None=�6c   5L   +   5N   #   5P      5Q      5S      5U      ]� 5W   
   -   5        $��ContentContract��5W      $��2��6,   $��0��5Z      ���	#B2000000y�5X      �� *
IsShowItem+  BoolToVisibility �� 	Converter# [ .+�5\      �� $	��8pxq�6   $��Bottom=�6&   $ 
Horizontal=�6>   $��RightToLeft=�6W   .+�5]      �� $	��8pxq�6   $��100px��6&     AccentedSquareButtonStyle#��[ 64   y�5^      �� *Mode+  ViewModeToVisablity# [   Add �� ConverterParameter# [ ��5a      �� *SaveCommand+.��69   Save6?   �� 5b      $	��8pxq�6   $��100px��6&   #��[ 64   y�5c      �� *Mode+# [   Edit# [ ��5f      �� *UpdateCommand+.��6;   Update6C   �� 5g      $	��8pxq�6   $��100px��6&    	 SquareButtonStyle#��� 	 64   ��5h      �� *CloseCommand+.��6:   Close6A   5i         UI.View.ContractView  5j      -   5          Name$ contractView��5j   >   $��500px��6    $��0,40pxq�6.   
������� � DataContext 6i   �� *SelectedItemVM+5k      5l      5m      