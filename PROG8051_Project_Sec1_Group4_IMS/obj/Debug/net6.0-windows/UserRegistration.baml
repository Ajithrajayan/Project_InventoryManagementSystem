   M S B A M L   `   `   `  ����[  WPROG8051_Project_Sec1_Group4_IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PROG8051_Project_Sec1_Group4_IMS PROG8051_Project_Sec1_Group4_IMS  5   	   7    1PROG8051_Project_Sec1_Group4_IMS.UserRegistration   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PROG8051_Project_Sec1_Group4_IMS     5   	     � WindowState$  	Maximized=�5   	    � Title$! Inventory Management System��5
   	   $	��800��6-   $	��800��6:   .��5      � ���	#FFE1FFFE$��
0,0,-651,0q�6#   $	��784��67   $	��Top=�6D    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    .+�5      o� .@�5      m� -   5         m�Name$ 	dashboard��5      $�� DASHBOARD ��6.   6D   m� 5      -   5        $ 
categories��5      $�� CATEGORIES ��6/   6F   m� 5      -   5        $ products��5      $��
 PRODUCTS ��6-   6A   m� 5      -   5        $ customer��5      $��
 CUSTOMER ��6-   6B   m� 5      -   5        $ order��5      $�� ORDER ��6*   6<   m� 5      -   5        $ employee��5      $��
 EMPLOYEE ��6-   6B   5       � 5      -   5          �Name$ 	mainFrame��5      $��1��6'   5      � 5    
   $��0,0,84,0q�6    5!      �� 5"      $��50 �6    �� 5#      $��40 �6    .+�5%      �� -   5         ��Name$ Label_login��5%   8   $��	0,45,0,-5q�6   $��2��6'   $��						EMPLOYEE��6M   $��Britannic Bold)�6~   $��24(�6�   $
��Bold"�6�   5&      �� 5(   
   $��	User Name��6   $
��Left=�6$   $��
80,140,0,0q�6?   $	��Top=�6S   $��26��6k   $��97��6w   �� 5)   
   $��	Full Name��6   $
��Left=�6$   $��
80,180,0,0q�6?   $	��Top=�6S   $��26��6k   $	��100��6w   �� 5*   
   $��Password��6   $
��Left=�6#   $��
80,220,0,0q�6>   $	��Top=�6R   $��26��6j   $��60��6v   �� 5+   
   $��Confirm Password��6   $
��Left=�6+   $��
80,260,0,0q�6F   $	��Top=�6Z   $��26��6r   $	��105��6~   �� 5,   
   $
��Role��6   $
��Left=�6   $��
80,300,0,0q�6:   $	��Top=�6N   $��26��6f   $	��105��6r   �� 5-   
   $��Mobile��6   $
��Left=�6!   $��
80,340,0,0q�6<   $	��Top=�6P   $��26��6h   $��47��6t   �� 50   
   -	   5         ��Name$ TextBox_UserName��50      $
��Left=�6-   $��240,132,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��273��6�   $��36��6�   �� 51   
   -
   5        $ TextBox_FName��51      $
��Left=�6*   $��240,172,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $	��273��6�   $��36��6�   �� 52   
   -   5        $ TextBox_Password��52      $
��Left=�6-   $��240,212,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��273��6�   $��36��6�   �� 53   
   -   5        $ TextBox_CPassword��53      $
��Left=�6.   $��240,252,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��273��6�   $��36��6�   �� 54   
   -   5        $ TextBox_Role��54      $
��Left=�6*   $��Enter A or E��6E   $��240,292,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $	��273��6�   $��36��6�   6�   �� 55   
   -   5        $ TextBox_Mobile��55      $
��Left=�6+   $��240,332,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��273��6�   $��36��6�   �� 57   
   -   5        	 ��Name$	 Button_Employee_Add��57      $	��ADD��6/   $
��Left=�6=   $��240,432,0,0q�6X   $	��Top=�6m   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  &   System.Windows.Controls.DataGrid  59   
   -   5        
  Name$
 DataGrid_EmployeeData��59         
IsReadOnly$
 True��62      AutoGenerateColumns$ False��6D   $
��Left=�6`   $��580,132,0,0q�6{   $	��Top=�6�   $	��523��6�   $	��453��6�    � 	Resources 5:      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5;      "  6   .�5<      ��  � ��
 ���@�63   �� 5=       � ��$ 0,0,1,2q�68   �� 5>       � ��
 �   �64   5?      5@         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$	  ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 10 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *	USER_ID+6N     5C      $ 
 User Name��6%   $ * 6W    69   �� *	USER_NAME+6W     5D      $ 
 Full Name��6%   $ * 6X    6:   �� *	Full_Name+6X     5E      $ 	 Password��6%   $ * 6U    68   �� *
Password+6U     5F      $  Role��6%   $ * 6N    65   �� *Role+6N     5G      $  Contact��6%   $ * 6W    68   �� *
Contact_No+6W   5I      �� 5K   
   -   5        $	 Button_Employee_Update��5K      $��UPDATE��62   $
��Left=�6C   $��580,600,0,0q�6^   $	��Top=�6s   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  �� 5L   
   -   5        $	 Button_Employee_Delete��5L      $��DELETE��62   $
��Left=�6C   $��740,600,0,0q�6^   $	��Top=�6s   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  5X      5Z      