   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.logWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
WeatherApp��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5        $��_Exit��5      6*   5      5      � 5   
   -   5         �Name$ myGrid��5      $��0,0,0,-6q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��logsDataDatagrid��5      $��
0,50,0,200q�60   $y�Visible=�6D   "   VerticalScrollBarVisibility$
 Auto=�6Y      AutoGenerateColumns$ False��6|   $��Center=�6�   $	��780��6�   
���   ���6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67      
IsReadOnly$
 True��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� 	 �� Path$	 dateTime�  5      $
 Type��6)   $ 80 67   $
 True��6B    6T   �� $
	 type�  5      $
 Json��6)   $	 500 67   $
 True��6C    6U   �� $
	 json�5        5      -   5        $��logsErrorDatagrid��5      $��9,256,44,49q�61   
�������$y�Visible=�6Z   $ Disabled=�6o   $ False��6�    5        5      $
 Date��6)   $ 80 67   $
 True��6B    6T   �� $	 dateTime�  5      $ Location��6)   $	 100 6;   $
 True��6G    6Y   �� $	 errorLocation�  5      $ Message��6)   $	 500 6:   $
 True��6F    6X   �� $	 erroMessage�5       �� 5!      -   5        $��Close��5!      $
��Left=�6%   $��690,367,0,0q�6@   $	��Top=�6U   $��21��6m   $��82��6y   6�   �� 5"      $
��Data��6   $
��Left=�6#   $��9,24,0,0q�6>   $	��Top=�6P   
 J� RenderTransformOrigin$
 0.543,0.492&�6h   ���	#FF5096D66�   �� 5#      $��Errors��6   $
��Left=�6%   $��
10,232,0,0q�6@   $	��Top=�6T   $
 0.543,0.492&�6l   ���	#FF5096D66�   �� 5$      -   5         ��Name$ tb_apiCalls��5$      $
��Left=�6+   $��	755,8,0,0q�6F    �� TextWrapping$
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��35��6�   �� 5%      $��API Number of Calls��6   $
��Left=�62   $��	641,4,0,0q�6M   $	��Top=�6`   �� 5&      -   5        $��Refresh��5&      $
��Left=�6'   $��
10,368,0,0q�6B   $	��Top=�6V   $��20��6n   6z   5'      5)      5.      