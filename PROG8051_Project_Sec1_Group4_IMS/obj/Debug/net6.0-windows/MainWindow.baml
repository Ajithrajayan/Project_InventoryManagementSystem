   M S B A M L   `   `   `  ����[  WPROG8051_Project_Sec1_Group4_IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PROG8051_Project_Sec1_Group4_IMS PROG8051_Project_Sec1_Group4_IMS  5   	   1    +PROG8051_Project_Sec1_Group4_IMS.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PROG8051_Project_Sec1_Group4_IMS     5   	     � WindowState$  	Maximized=�5   	    � Title$! Inventory Management System��5
   	   $	��518��6-   $	��816��6:   ���	#FF57E1F4 � 	Resources 5         GradientStopColor1��%+   &	        ��5   
   	#00FFFFFF��66   5      .��5      � $��	0,0,0,-16q�6    J� RenderTransformOrigin$ 0.5,0.5&�6   ���	#FFE1FFFE � RowDefinitions 5   
   �� 5      �� 5      $��0* �6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $
��797* �6   �� 5      $��3* �6   z�5   
   V� 5      .~�5      �� �� 5       �� 5!       �� Angle$ -0.252Q�6"   T� 5"      5#      .+�5%   
   	� -   5         	�Name$ RadioButton_Admin��5%      $��ADMIN��61   $
��Left=�6A   $��230,127,0,0q�6\   $	��Top=�6q   $��32��6�   $	��129��6�   $��6��6�   $
��Bold"�6�   $��14(�6�   	� 5&   
   -   5        $ RadioButton_Employee��5&      $��EMPLOYEE��64   $
��Left=�6G   $��451,127,0,0q�6b   $	��Top=�6w   $��32��6�   $	��129��6�   4  .System.Windows.Automation.AutomationProperties   Name$  ��6�   $��6��6�   $
��Bold"�6�   $��14(�6  �� 5(   
   -   5        	 ��Name$	 Label_login��5(      $��LOGIN��6%   $
��Left=�65   $��
312,31,0,0q�6P   $	��Top=�6d   $	��149��6|   $��68��6�   $��6��6�   $��Trebuchet MS)�6�   $
��Bold"�6�   $��48(�6�   �� 5)   
   -   5        $	 Label_userName��5)      $��	USER NAME��6(   $
��Left=�6<   $��193,227,0,0q�6W   $	��Top=�6l   $	��103��6�   $��6��6�   $��26��6�   $
��Bold"�6�   $��14(�6�   �� 5*   
   -   5        $	 Label_password��5*      $��PASSWORD��6)   $
��Left=�6<   $��193,292,0,0q�6W   $	��Top=�6l   $��90��6�   $��37��6�   $ -0.371,0.146&�6�   $��6��6�   $
��Bold"�6�   $��14(�6�   �� 5,   
   -   5        
 ��Name$
 TextBox_userName��5,      $
��Left=�6-   $��374,222,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��273��6�   $��36��6�   $��6��6�   G� 5-   
   -   5         G�Name$ TextBox_password��5-       G� PasswordChar$ *��61   $
��Left=�6C   $��374,287,0,0q�6^   $	��Top=�6t   $	��274��6�   $��40��6�   $��6��6�   �� 5.   
   -   5         ��Name$ Button_login��5.      $��LOGIN��6(   $
��Left=�68   $��339,387,0,0q�6S   $	��Top=�6h   $��47��6�   $	��143��6�   $��6��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  50      51      