   M S B A M L   `   `   `  ����E  AWheaterApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WheaterApp.MVVM.ViewWheaterApp.MVVM.View  5      #    WheaterApp.MVVM.View.LogsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WheaterApp.MVVM.View     5      .��5
      �� ._�5   
   � -   5          �Name$  myGrid��5      $��0,0,0,-6q�6    � RowDefinitions 5      �� 5      $	��250 �6    �� 5      .+�5      �� $��0��6   $
��Data��6!   ���	#FF5096D660   �� 5      -   5         ��Name$ 	apiNumber��5   !   $��0��6   $��[value]��64   $��	800,0,0,0q�6F   ���	#FF5096D66Y   �� 5      $��0��6   $��API Number of Calls��6!   $��	686,0,0,0q�6@   &   System.Windows.Controls.DataGrid  5      -   5        $��logsDataDatagrid��5   $   $��0��6   $��	0,40,20,0q�6=   $y�Visible=�6P   "   VerticalScrollBarVisibility$
 Auto=�6e      AutoGenerateColumns .  
���   ���6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6U   �� 
 �� Path$
 dateTime�  5      $
 Type��6)   $ 80 67    . 	 6T   �� $

 type�  5      $
 Json��6)   $	 500 67    . 	 6U   �� $

 json�5        5      -   5        $��logsErrorDatagrid��5   $   $��1��6   $��
0,30,20,20q�6>   
�������$y�Visible=�6f   $ Disabled=�6{    .   5        5      $
 Date��6)   $ 80 67    . 	 6T   �� $
 dateTime�  5       $ Location��6)   $	 100 6;    . 	 6Y   �� $
 errorLocation�  5!      $ Message��6)   $	 500 6:    . 	 6X   �� $
 erroMessage�5#      �� 5%      $��1��6   $��Errors��6!   ���	#FF5096D662   5&      5(      5+      