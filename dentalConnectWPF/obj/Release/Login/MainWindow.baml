   M S B A M L   `   `   `  ����   dentalConnectWPF'    !dentalConnectWPF.Login.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  	LoginView��$	��550��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  � Icon$ /Logos/logo1.png��.����  �� CornerRadius$ 12��._��� $ 10��$��2q� J� Opacity$
 0.95Q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 #32403B�� � Offset$ 0Q�� $
 #C9FFEB��$
 0.75Q�� $
 #7C9C90��$ 1Q����� $	 0,1&�$		 1,0&�.��� $
 #B5E6D4��$ 0Q�� $
 #658076��$ 1Q�._��  � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��INICIO DE SESIÓN��
�������$��18(�$��
Montserrat)�$��0��$��Center=�$��10,0,0,0q�$
��Bold"��� -    ��Name$ btnMinimize��$��0q�$��-��
�������$��16(�$��
Montserrat)� � Cursor$
 Hand��$��1������  �� 
TargetType" ��.���  �� Property � �� �� Value �#7C9C90 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 � �������  �� 
TargetType" ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� -   $ btnClose��$��0q�$��X��
�������$��12(�$��
Montserrat)�$
 Hand��$��2������ " ��.���  � �� �#658076 P�  �@J�IsMouseOver . . ���  � ��
 �  ������ " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $	��220��$��1�� �� Orientation$ Vertical=�$��0,35,0,0q�.+��� $	��130��$	��120��$��/Logos/logo1.png���� $��CODENSA��
�������$��36(�$��Medium"�$��
Montserrat)�$��Center=��� $��POWER BY QUANTUMBYTE��
�������$��14(�$��Medium"�$��
Montserrat)�$
��Wrap=� �� TextAlignment$ Center=�$��0,5,0,0q��� $��Usuario��
�������$��12(�$��Medium"�$��
Montserrat)�$��0,35,0,0q��� -    ��Name$ txtUser��$��13(�$��Medium"�$��
Montserrat)�
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�$��28��$��Center=�$��0,5,0,0q�$��20,0,0,0q�.������  �� ImageSource$ /Logos/user1898.png�� j� Stretch$ Uniform=� j� 
AlignmentX$
 Left=�.���� $��Contraseña��
�������$��12(�$��Medium"�$��
Montserrat)�$��0,15,0,0q�G� -    G�Name$ txtPass��$��13(�$��Medium"�$��
Montserrat)�
������� G� 
CaretBrush
 �����
�������$��0,0,0,2q�$��28��$��Center=�$��20,0,0,0q����� $ /Logos/cerrar.png��$ Uniform=�$
 Left=��� -   $ btnLogin��$��0q�$��INGRESAR��
�������$��12(�$��
Montserrat)�$
 Hand��$��0,50,0,0q����� " ��.���  � �� �#32403B P�  �@J�IsMouseOver . . ���  � �� �#112c52���� " ��.R��� $	��150��$��40��$ 20��#��z��._��� $��Center=�$��Center=��� $ 
Horizontal=�$��Center=�$��0,15,0,0q��� -     ��Name$  txbError��$��Center=�$��	0,356,0,0q�$��1��$
��Wrap=�$	��Top=�$	��220��$��25��$��16(�$ Center=�