   M S B A M L   `   `   `  ����   dentalConnectWPF(    "dentalConnectWPF.Functions.winUser   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  MenuView��$	��750��$
��1500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  � Icon$ /Functions/user1.png��.����  �� CornerRadius$ 12��._��� $ 10��$��2q� J� Opacity$
 0.95Q�$��0,2,0,-2q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 #32403B�� � Offset$ 0Q�� $
 #C9FFEB��$
 0.75Q�� $
 #7C9C90��$ 1Q����� $	 0,1&�$		 1,0&�.��� $
 #B5E6D4��$ 0Q�� $
 #658076��$ 1Q�._��  � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��USUARIOS��
�������$��18(�$��
Montserrat)�$��0��$��Center=�$��	30,0,17,0q�$
��Bold"��� -    ��Name$ btnMinimize��$��0q�$��-��
�������$��16(�$��
Montserrat)� � Cursor$
 Hand��$��1������  �� 
TargetType" ��.���  �� Property � �� �� Value �#7C9C90 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 � �������  �� 
TargetType" ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� -   $ btnClose��$��0q�$��X��
�������$��12(�$��
Montserrat)�$
 Hand��$��2������ " ��.���  � �� �#658076 P�  �@J�IsMouseOver . . ���  � ��
 �  ������ " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $��USUARIOS�����#32403B$��48(�$
��Bold"�$��
Montserrat)�$
��Left=�$��110,5,0,660q�$	��272��$��1���� $��Nombre:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��22,124,0,560q�$	��121��$��1���� -    ��Name$ txbName��$
��Left=�$��336,114,0,0q�$��1�� �� TextWrapping$ NoWrap=�$	��Top=�$	��226��$��43��$��24(�
������� K� ZIndex$ 1��$��Medium"�&   System.Windows.Controls.DataGrid  -     Name$ dgDatos��$��1��$��10,396,35,46q�
������    CanUserAddRows .     
IsReadOnly . �� -    ��Name$ 
txtMessage��$
��Left=�$��10,0,0,0q�$��1��$
��Wrap=�$��Center=�$	��818��$��44��$��20(��� -   $ btnMenu��$��0q�$��<-��
�������$��12(�$��
Montserrat)�$
 Hand��$��5,0,0,0q� J� RenderTransformOrigin$ 0.5,0.5&�$
��Left=�$��23��z�V� .~��� ��  �� AngleY$ -1.128Q��� T�   T� Y$  -1.23Q����� " ��.���  � �� �#658076 P�  �@J�IsMouseOver . . ���  � ��
 � d ����� " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $��Primer Apellido:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��22,177,0,507q�$	��242��$��1���� $��Segundo Apellido:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��22,230,0,454q�$	��274��$��1���� $	��CI:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��22,81,0,603q�$	��129��$��1���� $��
Teléfono:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��646,177,0,507q�$	��216��$��1���� $��Email:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��646,125,0,559q�$	��188��$��1���� $
��Rol:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��646,82,0,602q�$	��122��$��1���� -   $ txbLastName��$
��Left=�$��334,162,0,0q�$��1��$ NoWrap=�$	��Top=�$	��226��$��45��$��24(�
�������$ 2��$��Medium"�.���� -	   $ txbSecLastName��$
��Left=�$��336,214,0,0q�$��1��$ NoWrap=�$	��Top=�$	��226��$��44��$��24(�
�������$ 3���� -
   $ txbCI��$
��Left=�$��
336,69,0,0q�$ NoWrap=�$	��Top=�$	��226��$��43��$��24(�
�������$ 4��$��1��$��Medium"��� -   $ txbEmail��$
��Left=�$��790,113,0,0q�$��1��$ NoWrap=�$	��Top=�$	��264��$��45��$��24(�
�������$ 6��$��Medium"��� -   $ txbPhone��$
��Left=�$��796,164,0,0q�$��1��$ NoWrap=�$	��Top=�$	��258��$��41��$��24(�
�������$ 7��$��Medium"��� -   ! ��Name$! cbRole��$
��Left=�$��
795,72,0,0q�$��1��$	��Top=�$	��260��$��24(�$ 5��
���   ��� $��Sexo:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��645,231,0,453q�$	��216��$��1���� $��Fecha de Nacimiento:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��21,282,0,402q�$	��315��$��1���� -   $! cbGender��$
��Left=�$��45��$��795,219,0,0q�$��1��$	��Top=�$	��260��$��24(�$ 5��
���   �(  "System.Windows.Controls.DatePicker  -   "  Name$" dpBirthdate��$
��Left=�$��33��$��336,282,0,0q�$��1��$	��Top=�$	��226��$��20(�
���   ��� $��/Logos/user.png��$��28,0,1393,661q�$��1��'  !MaterialDesignThemes.Wpf.Snackbar  -   #  Name$# snackbar��$��75��$	��Top=�$	��626��$��2��$��
471,23,0,0q�$
��Left=�$��18(�$��Normal"�$   MessageQueue$ 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� -   $ btn_help_name��$�� ��$
��Left=�$��567,129,0,0q�$��1��$	��Top=�$��25��$��25��$ -0.231,0.48&���Z� ���� % �� ImageSource$% /Logos/help.png���� -   $ btn_help_CI��$�� ��$
��Left=�$��
567,86,0,0q�$��1��$	��Top=�$��25��$��25��$ -0.231,0.48&�$
 Hand����Z� ���� $% /Logos/help.png���� -   $ btn_help_Lname��$�� ��$
��Left=�$��567,177,0,0q�$��1��$	��Top=�$��25��$��25��$ -0.231,0.48&�$
 Hand����Z� ���� $% /Logos/help.png���� -   $ btn_help_SLname��$�� ��$
��Left=�$��567,232,0,0q�$��1��$	��Top=�$��25��$��25��$ -0.231,0.48&���Z� ���� $% /Logos/help.png���� -   $ btn_help_email��$�� ��$
��Left=�$��1059,129,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&���Z� ���� $% /Logos/help.png���� -   $ btn_help_phone��$�� ��$
��Left=�$��1059,178,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&���Z� ���� $% /Logos/help.png���� -   $ btn_help_date��$�� ��$
��Left=�$��567,283,0,0q�$��1��$	��Top=�$��25��$��25��$ -0.231,0.48&���Z� ���� $% /Logos/help.png���� -   $ 	btnInsert��$	��➕��$
��Left=�$��1191,154,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF386591���	#FF386591�� -   $ btnSave��$
��💾��$
��Left=�$��1191,122,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF3C7861���	#FF2A5746�� -   $ 	btnCancel��$	��❌��$
��Left=�$��1191,184,0,0q�$��1��$	��Top=�$	��146��$��44��$��24(����	#FF3C6162���	#FF314E4F