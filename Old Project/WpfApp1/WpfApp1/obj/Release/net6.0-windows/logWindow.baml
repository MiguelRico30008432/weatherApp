   M S B A M L   `   `   `  ���� E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.logWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1       � Title$  
WeatherApp��$	��450��$	��800��.��]� .+�o� $	��Top=�.@�m� $��_File��.@�m� $��_Exit��� -    �Name$ myGrid��$��0,0,0,-6q�.+�&   System.Windows.Controls.DataGrid  -   $��logsDataDatagrid��$��
0,39,0,182q�
�������$y�Visible=�#��� ��"   VerticalScrollBarVisibility$
 Auto=�   AutoGenerateColumns$ False��$��Center=�$	��780��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� 	 �� Path$	 dateTime�  $
 Type��$ 80 $
 True�� �� $
	 type�  $
 Json��$	 500 $
 True�� �� $
	 json�  -   $��logsErrorDatagrid��$��10,275,44,53q�
�������$y�Visible=�#��� ��$ Disabled=�$ False��$	��746��   $
 Type��$ 80 $
 True�� �� $
	 date�  $
 Json��$	 100 $
 True�� �� $
	 temp��� $��Close��$
��Left=�$��690,367,0,0q�$	��Top=�$��21��$��82���� $
��Data��$
��Left=�$��9,13,0,0q�$	��Top=�
 J� RenderTransformOrigin$
 0.543,0.492&��� $��Errors��$
��Left=�$��
10,249,0,0q�$	��Top=�$
 0.543,0.492&��� -    ��Name$ tb_apiCalls��$
��Left=�$��	755,8,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$��35���� $��API Number of Calls��$
��Left=�$��	641,4,0,0q�$	��Top=�