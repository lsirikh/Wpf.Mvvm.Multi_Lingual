# WPF MVVM 패턴을 활용한 Multi-Lingual Sample Program
## Goal : WPF에 활용되는 다국어 변환 로직을 다이나믹한 구조로 적용하는 방안을 모색해 본다.

## 적용 앱
* Wpf.Mvvm.Multi_Lingual.UI v1.0.0.0

## 적용 라이브러리
* Wpf.Mvvm.Library.Sample1 v1.0.0.0
* Wpf.Mvvm.Library.Language v1.0.0.0

## 종속 라이브러리
* Ironwall.Framework v1.0.0.0
* Ironwall.Libraries.Enums v1.0.0.0
* Ironwall.Libraries.Utils v1.0.0.0
  
## Nuget 라이브러리
* Autofac v6.5.0
* Caliburn.Micro v4.0.212
* Microsoft.Bcl.AsyncInterfaces v7.0.0

### 로직 내용
   1) Resource.xaml을 통해 DynamicResource로 언어 Resource를 변경해준다. 변경의 기준은 CulturInfo의 Name을 기준으로 한다.
   
   2) Properties에 Language를 위한 resx 파일을 추가하고 각 국가 언어 셋에 맞게 작성하고, CulturInfo를 런타임에 변경하는 로직을 활용하여, 프로그램 언어 기반을 변경한다. 해당 내용은 Wpf.Mvvm.Library.Language의 LanguageService를 참고 하면 된다.

## 참고 이미지

![샘플 프로그램](https://github.com/lsirikh/Wpf.Mvvm.Multi_Lingual/blob/main/Pictures/Korean.png "샘플 프로그램(한국어)")
한국어 선택 시

![샘플 프로그램](https://github.com/lsirikh/Wpf.Mvvm.Multi_Lingual/blob/main/Pictures/English.png "샘플 프로그램(영어)")
영어 선택 시