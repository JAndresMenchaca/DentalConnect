   M S B A M L   `   `   `  ����   dentalConnectWPF(    "dentalConnectWPF.Tools.winPassword   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  	LoginView��$	��475��$	��540�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  � Icon$ /Logos/logo1.png��.����  �� CornerRadius$ 12��._��� $ 10��$��2q� J� Opacity$
 0.95Q�$��0,-3,0,3q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 #32403B�� � Offset$ 0Q�� $
 #C9FFEB��$
 0.75Q�� $
 #7C9C90��$ 1Q����� $	 0,1&�$		 1,0&�.��� $
 #B5E6D4��$ 0Q�� $
 #658076��$ 1Q�._�� $��-2,0,0,0q� � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��CAMBIO DE CONTRASEÑA��
�������$��16(�$��
Montserrat)�$��0��$��Center=�$��	10,0,36,0q�$
��Bold"��� -    ��Name$ 
btnConfirm��$��Aceptar��$
��Left=�$��40��$��114,389,0,0q�$��1��$	��Top=�$	��131�� J� RenderTransformOrigin$ 0.5,0.5&�$��24(����	#FF2896C7���	#FF2896C7z�V� .~��� �� ��  �� Angle$ -0.153Q�T� �� -   $ 	btnCancel��$��Cancelar��$
��Left=�$��39��$��288,389,0,0q�$��1��$	��Top=�$	��130��$��24(����	#FFDC4A4A���	#FFDC4A4A�� -    ��Name$ txtError��$
��Left=�$��70��$��
35,314,0,0q�$��1��$
��Wrap=�$	��Top=�$	��356��$��18(��� $
��Left=�$��28��$��	35,77,0,0q�$��1��$
��Wrap=�$��Contraseña anterior: ��$	��Top=�$	��204�����#32403B$��20(�$��
Montserrat)� �� TextAlignment$ Center=��� $
��Left=�$��28��$��
33,157,0,0q�$��1��$
��Wrap=�$��Nueva contraseña: ��$	��Top=�$	��194�����#32403B$��20(�$��
Montserrat)�$ Center=��� $
��Left=�$��28��$��
35,241,0,0q�$��1��$
��Wrap=�$��Repita la contraseña: ��$	��Top=�$	��228�����#32403B$��20(�$��
Montserrat)�$ Center=��� $��Logos/i3.png��$��-27,0,414,393q�$��1���� $��CAMBIO DE CONTRASEÑA�����#32403B$��26(�$
��Bold"�$��
Montserrat)�$
��Left=�$��77,10,0,381q�$	��375��$��1���� -   $ btnClose��$��0q�$��X��
�������$��12(�$��
Montserrat)� � Cursor$
 Hand��$��454,4,-44,10q�����  �� 
TargetType" ��.���  �� Property � �� �� Value �#658076 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �  ������  �� 
TargetType" ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=�G� -    G�Name$ 
pbOriginal��$��13(�$��Medium"�$��
Montserrat)�
������� G� 
CaretBrush
 �����
�������$��0,0,0,2q�$��Center=�$��20,0,0,0q�$��35,110,47,303q�$��1��G� -   $ pbNew��$��13(�$��Medium"�$��
Montserrat)�
�������
 �����
�������$��0,0,0,2q�$��Center=�$��20,0,0,0q�$��35,192,47,221q�$��1��G� -   $ pbNew2��$��13(�$��Medium"�$��
Montserrat)�
�������
 �����
�������$��0,0,0,2q�$��Center=�$��20,0,0,0q�$��35,281,47,132q�$��1���� -   $ btn_help_password��$�� ��$
��Left=�$��496,187,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&�$
 Hand����Z� ����  �� ImageSource$ /Logos/help.png��'  !MaterialDesignThemes.Wpf.Snackbar  -	     Name$ snackbar��$��78��$	��Top=�$	��498��$��12(�$��Normal"�$
��Left=�$��	24,26,0,0q�$��2��   MessageQueue 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  