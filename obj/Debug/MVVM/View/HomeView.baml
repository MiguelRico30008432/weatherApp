   M S B A M L   `   `   `  ����E  AWheaterApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WheaterApp.MVVM.ViewWheaterApp.MVVM.View  5      #    WheaterApp.MVVM.View.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WheaterApp.MVVM.View     5      .��5
      ]� .+�5   
   � -   5          �Name$  myGrid��5      $��0,0,0,-6q�6   .+�5      �� -   5         ��Name$ bt_getResults��5      $��Results��6,   $
��Left=�6>   $��
228,22,0,0q�6Y   $	��Top=�6m   $��44��6�   $��25��6�   ���	#FF5096D6
����������	#FF5096D6$��Center=�6�   $��Center=�6   J� RenderTransformOrigin$ 0.535,0.484&�6@  �� 5      -   5         ��Name$ 
lbl_search��5      $��Search:��6(   $
��Left=�6:   $��4,2,0,0q�6U   $	��Top=�6f   $	��142��6~   ���	#FF5096D66�   �� 5      -   5         ��Name$ 	tb_search��5      $
��Left=�5      $��8,27,0,0q�5       �� TextWrapping$
 Wrap=�5      $�� ��5      $	��Top=�5      $	��217��5      $��20��5       �� 
AcceptsTab .    TextBoxBaseStyle#��[  5      ���	#FF5096D65      �� 5      -   5        $ lbl_selectRegion��5      $ ��Choose a especific region:��6.   $
��Left=�6S   $��4,46,0,0q�6n   $	��Top=�6�   $	��192��6�   $y�Visible=�6�   ���	#FF5096D66�   �� 5      -   5         ��Name$ comboBox��5      $
��Left=�6+   $��	10,70,0,0q�6F   $	��Top=�6Y   $	��344��6q   $y�Visible=�6}   
����������	#FF5096D6��5      �� 5       �� EndPoint$ 0.5,1&�6*   	 �� 
StartPoint$	 0.5,0&�6;   .��5       � 
 � Color$
 	#FFF0F0F0��6'   � 5!      $
 	#FFE5E5E5��6'    � Offset$ 1Q�69   5"      5$      �� 5(      -   5        $ 	lbl_today��5(      $��Current Weather��6'   $
��Left=�6A   $��
10,116,0,0q�6\   $	��Top=�6p   $
��Bold"�6�   ���	#FF5096D66�   �� 5*      -   5        $ lbl_dailyWeather��5*      $��Daily Weather��6.   $
��Left=�6F   $��401,116,0,0q�6a   $	��Top=�6v   $	��199��6�   $
��Bold"�6�   ���	#FF5096D66�   �� 5+      -	   5        $ 
lbl_t_temp��5+      $��Temperature��6(   $
��Left=�6>   $��
28,154,0,0q�6Y   $	��Top=�6m   $��80��6�   �� 5,      -
   5        $ lbl_t_temp_v��5,      $��{value}��6*   $
��Left=�6>   $��136,154,0,0q�6Y   $	��Top=�6n   $ 0.474,0.558&�6�   $��49��6�   �� 5-      -   5        $ lbl_t_temp_min��5-      $��Temperature Min.��6,   $
��Left=�6G   $��
28,180,0,0q�6b   $	��Top=�6v   �� 5.      -   5        $ lbl_t_temp_min_v��5.      $��{value}��6.   $
��Left=�6B   $��136,180,0,0q�6]   $	��Top=�6r   $ 0.474,0.558&�6�   $��49��6�   �� 5/      -   5        $ lbl_t_temp_max��5/      $��Temperature Max.��6,   $
��Left=�6G   $��
28,206,0,0q�6b   $	��Top=�6v   �� 50      -   5        $ lbl_t_temp_max_v��50      $��{value}��6.   $
��Left=�6B   $��136,206,0,0q�6]   $	��Top=�6r   $ 0.474,0.558&�6�   $��49��6�   �� 51      -   5        $ lbl_t_temp_sen��51      $��
Feels Like��6,   $
��Left=�6A   $��
28,232,0,0q�6\   $	��Top=�6p   $��80��6�   �� 52      -   5        $ lbl_t_temp_sen_v��52      $��{value}��6.   $
��Left=�6B   $��136,232,0,0q�6]   $	��Top=�6r   $ 0.474,0.558&�6�   $��49��6�   &   System.Windows.Controls.DataGrid  54      -   5        $��NextWeekDatagrid��54      $��401,156,10,42q�60   ���	#FF5096D6$y�Visible=�6_   
�������$   HorizontalScrollBarVisibility$ Disabled=�6�   "   VerticalScrollBarVisibility$
 Auto=�6�      AutoGenerateColumns .   J� OpacityMask
 �   �   Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$	 Day��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 66      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   ��  �� Path$
 date�  57      $ Temperature (ºC)��6)   $	 100 6C    .  6a   �� $
 temp�  58      $ Temp. Max(ºC)��6)   $ 90 6@    .  6]   �� $ tempMax�  59      $ Temp. Min(ºC)��6)   $ 90 6@    .  6]   �� $ tempMin�  5:      $ Feels Like(ºC)��6)   $ 90 6A    .  6^   �� $ 	feelsLike�5<      �� 5=      $
��Left=�6   $��1��63   $��401,141,0,0q�6>   
���   �$	��Top=�6b   $	��487��6z   $ 0.5,0.5&�6�   z�5>      V� 5?      .~�5@      ��  �� ScaleY$ -1Q�6)   �� 5A      �� 5B      T� 5C      5D      5F      �� 5G      $
��Left=�6   $��1��63   $��
10,141,0,0q�6>   
���   �$	��Top=�6a   $	��186��6y   $ 0.5,0.5&�6�   z�5H      V� 5I      .~�5J      �� $ -1Q�6)   �� 5K      �� 5L      T� 5M      5N      5P      5R      5S      5T      