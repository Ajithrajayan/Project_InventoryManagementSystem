   M S B A M L   `   `   `  ����[  WPROG8051_Project_Sec1_Group4_IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PROG8051_Project_Sec1_Group4_IMS PROG8051_Project_Sec1_Group4_IMS  5   	   0    *PROG8051_Project_Sec1_Group4_IMS.Customers   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PROG8051_Project_Sec1_Group4_IMS     5   	     � WindowState$  	Maximized=�5   
    � Title$! Inventory Management System��5	   	   $	��800��6-   $	��800��6:   .��5
      � ���	#FFE1FFFE$��
0,0,-651,0q�6#   $	��784��67   $	��Top=�6D    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    .+�5      o� .@�5      m� -   5         m�Name$ 	dashboard��5      $�� DASHBOARD ��6.   6D   m� 5      -   5        $ 
categories��5      $�� CATEGORIES ��6/   6F   m� 5      -   5        $ products��5      $��
 PRODUCTS ��6-   6A   m� 5      -   5        $ customer��5      $��
 CUSTOMER ��6-   6B   m� 5      -   5        $ order��5      $�� ORDER ��6*   6<   m� 5      -   5        $ employee��5      $��
 EMPLOYEE ��6-   6B   5       � 5      -   5          �Name$ 	mainFrame��5      $��1��6'   5      � 5   
    5       �� 5!      $��50 �6    �� 5"      $��40 �6    .+�5$      �� -   5         ��Name$ Label_login��5$   8   $��	0,45,0,-5q�6   $��2��6'   $��						CUSTOMERS��6M   $��Britannic Bold)�6   $��24(�6�   $
��Bold"�6�   5%      �� 5'   
   -	   5        $ Label_ID��5'      $��ID��6"   $
��Left=�6/   $��
80,140,0,0q�6J   $	��Top=�6^   $��26��6v   $��22��6�   �� 5(   
   -
   5        $ Label_FName��5(      $��
First Name��6%   $
��Left=�6:   $��
80,180,0,0q�6U   $	��Top=�6i   $��26��6�   $��97��6�   �� 5)   
   -   5        $ Label_LName��5)      $��	Last Name��6%   $
��Left=�69   $��
80,220,0,0q�6T   $	��Top=�6h   $��26��6�   $��97��6�   �� 5*   
   -   5        $ Label_Mobile��5*      $��Mobile��6&   $
��Left=�67   $��
80,260,0,0q�6R   $	��Top=�6f   $��26��6~   $	��105��6�   �� 5+   
   -   5        $ Label_Email��5+      $��Email��6%   $
��Left=�65   $��
80,300,0,0q�6P   $	��Top=�6d   $��26��6|   $��47��6�   �� 5-   
   -   5         ��Name$ 
TextBox_ID��5-      $
��Left=�6'    �� 
IsReadOnly$
 True��6B   $��240,132,0,0q�6T   	 �� TextWrapping$
	 Wrap=�6i   $	��Top=�6}   $	��273��6�   $��36��6�   �� 5.   
   -   5        $ TextBox_FName��5.      $
��Left=�6*   $��240,172,0,0q�6E   $
	 Wrap=�6Z   $	��Top=�6n   $	��273��6�   $��36��6�   �� 5/   
   -   5        $ TextBox_LName��5/      $
��Left=�6*   $��240,212,0,0q�6E   $
	 Wrap=�6Z   $	��Top=�6n   $	��273��6�   $��36��6�   �� 50   
   -   5        $ TextBox_Mobile��50      $
��Left=�6+   $��240,252,0,0q�6F   $
	 Wrap=�6[   $	��Top=�6o   $	��273��6�   $��36��6�   �� 51   
   -   5        $ TextBox_Email��51      $
��Left=�6*   $��240,292,0,0q�6E   $
	 Wrap=�6Z   $	��Top=�6n   $	��273��6�   $��36��6�   �� 53   
   -   5        
 ��Name$
 Button_Customers_Add��53      $	��ADD��60   $
��Left=�6>   $��230,392,0,0q�6Y   $	��Top=�6n   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6�   $��2��6�   6  &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ DataGrid_CustomerDetails��54         
IsReadOnly$
 True��65      AutoGenerateColumns$ False��6G   $
��Left=�6c   $��550,132,0,0q�6~   $	��Top=�6�   $	��700��6�   $	��284��6�    � 	Resources 55      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 56      "  6   .�57      ��  � ��
 ���@�63   �� 58       � ��$ 0,0,1,2q�68   �� 59       � ��
 �   �64   5:      5;         Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$
  ID ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 15 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Customer_ID+6S     5>      $  First Name ��6%   $ * 6^    6;   �� *Customer_Fname+6^     5?      $  Last Name ��6%   $ * 6]    6:   �� *Customer_Lname+6]     5@      $ 	 Contact ��6%   $ * 6]    68   �� *Customer_Contact+6]     5A      $  Email ��6%   $ * 6Y    66   �� *Customer_Email+6Y   5E      �� 5F   
   -   5        $
 Button_Customers_Update��5F      $��UPDATE��63   $
��Left=�6D   $��580,450,0,0q�6_   $	��Top=�6t   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6�   $��2��6�   6  �� 5G   
   -   5        $
 Button_Customers_Delete��5G      $��DELETE��63   $
��Left=�6D   $��740,450,0,0q�6_   $	��Top=�6t   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6�   $��2��6�   6  �� 5H   
   -   5        $!
 Button_Customers_OrderCount��5H      $��ORDER COUNT��67   $y�Hidden=�6M   $
��Left=�6a   $��
70,550,0,0q�6|   $	��Top=�6�   $	��100��6�   $	��250��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  �� 5I   
   -   5        $'
 !Button_Customers_TotalOrderAmount��5I      $��TOTAL ORDER COUNT��6=   $y�Hidden=�6Y   $
��Left=�6m   $��550,550,0,0q�6�   $	��Top=�6�   $	��100��6�   $	��250��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6  $��24(�6  $��2��6!  �� 5J   
   -   5        $$
 Button_Customers_LastOrderDate��5J      $��LAST ORDER DATE��6:   $y�Hidden=�6T   $
��Left=�6h   $��1000,550,0,0q�6�   $	��Top=�6�   $	��100��6�   $	��250��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  5K      5L      