   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5   	   %localclr-namespace:WpfApp1    5   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ Registration��5	   	   $	��400��6   $	��600��6+   .��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��0��6!   $��3��6.   ���#84A7DC._�5      �� $��0��6   $��0��6(   $��3��65   $-��'ОНЛАЙН ЗАПИСЬ К ВРАЧУ��6I   $��Raleway)�6f   $��34(�5      
������� �� TextAlignment$ Center=�69   $��Center=�6P   6n   5      �� 5   
   $��0��6   $��1��6!   $��3��6.   ._�5      �� $	��Top=�6   $��Raleway)�60   $��83��6E   $	��533��6Q   $��36(�6]   $ Center=�6k   ���	#FF4B6997$
��Left=�5   /   $��29,0,0,0q�6J   �� 6]   $;�5Запишитесь к врачу с помощью ��6a   �� 6�   �� 5      $8�2нашего удобного приложения��6   ���	#FF4B699768   6R   5      �� 5    
   -   5         ��Name$ register��5       $��2��6:   $��28,25,172,24q�6G   ���	#FF84A7DC
�������$��ЗАПИСАТЬСЯ��5!   $   $��28(�6P   $��Raleway)�6^   $��2��6s    J� RenderTransformOrigin$ 0.522,0.251&�6�   ��69   Z�  � 	Resources 5"       �� 
TargetType	 �� Property
 �� Value��%_   '��       �� 5#      " ��6   .�5$      �� 	 �@��CornerRadius$
 10��65   5%      5&      5'      �� 5)   
   -   5        $ addInf��5)      $��3��6!   $��112,25,112,25q�6.   ���	#FF84A7DC
�������$+��%ДОБАВИТЬ ИНФОРМАЦИЮ��5*      $��28(�6Q   $��Raleway)�6_   $��3��6t   ��6:   Z�  5+      ��%_   '��       �� 5,      " ��6   .�5-      �� 	 �@��CornerRadius$
 10��65   5.      5/      50      �� 51   
   -   5        $ 	checckInf��51      $��2��68   $��59,25,27,24q�6E   ���	#FF84A7DC
�������$'��!АКТУАЛЬНАЯ ЗАПИСЬ��52       $��28(�6S   $��Raleway)�6a   $��1��6v   $��2��6�   ��6<   Z�  53      ��%_   '��       �� 54      " ��6   .�55      �� 	 �@��CornerRadius$
 10��65   56      57      58      59      5:      