   M S B A M L   `   `   `  ���� E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1       � Title$  
WeatherApp��$	��450��$	��800��.��]� .+�o� $	��Top=�.@�m� $��_File��.@�m� $��_Exit��m� -   $
��Logs��� -    �Name$ myGrid��$��0,0,0,-6q�.+��� -    ��Name$ bt_getResults��$��Get Results��$
��Left=�$��
243,35,0,0q�$	��Top=�$	��109���� -    ��Name$ 
lbl_search��$��Search:��$
��Left=�$��4,11,0,0q�$	��Top=�$	��142���� -    ��Name$ 	tb_search��$
��Left=�$��8,36,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��217�� �� 
AcceptsTab$
 True���� -   $ lbl_selectRegion��$ ��Choose a especific region:��$
��Left=�$��	425,8,0,0q�$	��Top=�$	��192��$y�Visible=��� -    ��Name$ comboBox��$
��Left=�$��
431,32,0,0q�$	��Top=�$	��344��$y�Visible=��� -   $ 	lbl_today��$��Current Weather��$
��Left=�$��
53,117,0,0q�$	��Top=�$
��Bold"��� -	   $ lbl_dailyWeather��$��Daily Weather��$
��Left=�$��320,116,0,0q�$	��Top=�$	��200��$
��Bold"��� -
   $ 
lbl_t_temp��$��Temperature��$
��Left=�$��
55,156,0,0q�$	��Top=�$��80���� -   $ lbl_t_temp_v��$��{value}��$
��Left=�$��163,156,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.474,0.558&�$��49���� -   $ lbl_t_temp_min��$��Temperature Min.��$
��Left=�$��
55,182,0,0q�$	��Top=��� -   $ lbl_t_temp_min_v��$��{value}��$
��Left=�$��163,182,0,0q�$	��Top=�$ 0.474,0.558&�$��49���� -   $ lbl_t_temp_max��$��Temperature Max.��$
��Left=�$��
55,208,0,0q�$	��Top=��� -   $ lbl_t_temp_max_v��$��{value}��$
��Left=�$��163,208,0,0q�$	��Top=�$ 0.474,0.558&�$��49���� -   $ lbl_t_temp_sen��$��
Feels Like��$
��Left=�$��
55,234,0,0q�$	��Top=�$��80���� -   $ lbl_t_temp_sen_v��$��{value}��$
��Left=�$��163,234,0,0q�$	��Top=�$ 0.474,0.558&�$��49��&   System.Windows.Controls.DataGrid  -   $��NextWeekDatagrid��$��320,156,10,42q�
�������$y�Visible=�#��� ��"	   VerticalScrollBarVisibility$
	 Auto=�
   AutoGenerateColumns$
 False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Day��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80    
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$
 date�  $ Temperature (ºC)��$	 100 $
 True�� �� $
 temp�  $ Temp. Max(ºC)��$ 90 $
 True�� �� $ tempMax�  $ Temp. Min(ºC)��$ 90 $
 True�� �� $ tempMin�  $ 
Feels Like��$ 90 $
 True�� �� $ 	feelsLike��� $��Center=�$��1��$��	0,142,0,0q�
���   �$	��Top=�$	��780��$ 0.5,0.5&�z�V� .~���  �� ScaleY$ -1Q��� �� T� 