   M S B A M L   `   `   `  ����F  BCloudPoints, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CloudPointsCloudPoints  5   	       CloudPoints.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CloudPoints     5   	     � Title$  
MainWindow��5   	   $��529.339��6   $��1016.942��6-   .��5	      � -   5         �Name$ MainGrid��5	       � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   $��Stretch=�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��0.30* �6#   .+�5      �� $��0��6   .+�5      �� -   5         ��Name$ PointsNumber��5      $	��200��60   6l   5      � 5      $��1��6    5      �� 5      $
��0.5* �6'   �� 5      $
��0.5* �6'   .+�5      �� -   5         ��Name$	 NxN��5      $��0��6&   .��6I   O(N*N)6Q   �� 5       -   5        $ NxlogN��5       $��1��6)   .��6O   
O(N·logN)6Z   5!      5#      �� 5&   
   -   5        $��CanvasEscenario��5&      $��
10,5,10,10q�6(   $��1��6<   �� 5)   
   $��2��6   �� 5*      .�6   Iteraciones:6!    �� 5+      -   5         ��Name$
 Iter��5+      .�6    06#   5,      5.      5/      