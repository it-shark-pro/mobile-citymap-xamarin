# City Map - Android & iOS applications (C#)

В данном репозитории расположены различные материалы для пошагового создания с нуля простого мобильного приложения **City Map** для платформ **Android** и **iOS**, на языке программирования **C#**.

**City Map** - мобильное приложения для просмотра базовой информации о различных городах.

### Основные функции:
- Постраничная навигация;
- Загрузка данных из сети;
- Оффлайн доступ к данным;
- Отображение городов на мировой карте.

## Для чего?

Если вас когда-либо интересовала возможность создания нативных приложений для **iOS** и **Android** на **C#** и .NET с помощью **Xamarin** и Вы хотели бы попробовать себя в этом, то вы можете попробовать начать изучение используя материалы из данного репозитория.

## Что нужно, чтобы начать?

Для того, чтобы начать изучать нативную мобильную разработку на **Xamarin**, Вам понадобится:
- Базовые знания английского языка (для чтения материалов);
- Базовые знания языка программирования **С#**;
- Среда разработки [**Visual Studio IDE**](https://www.visualstudio.com/vs/) (Community 2017 или выше) с установленным Xamarin и набором SDK для Android и iOS;
- Базовые навыки работы с [**Git**](https://try.github.io/levels/1/challenges/1) (для работы с материалами данного репозитория);
- Для создания iOS приложений:
  - Компьютер, работающий под управлением операционной системы **Mac OS** (High Sierra и выше);
  - Среда разработки **XCode** (версии 9.2 и выше).

## Установка и настройка

- [Системные требования](https://docs.microsoft.com/ru-ru/xamarin/cross-platform/get-started/requirements)
- [Установка Xamarin для Visual Studio в Windows](https://docs.microsoft.com/ru-ru/xamarin/cross-platform/get-started/installation/windows)
- [Настройка и установка Visual Studio для Mac](https://docs.microsoft.com/ru-ru/visualstudio/mac/installation)

## Задания

Мы предлагаем Вам познакомиться с нативной разработкой под платформы **iOS** и **Android**, путем последовательного выполнения заданий по созданию приложения **CityMap**.

### Часть 0

В рамках данного задания требуется создать новый проект с одним экраном.
При необходимости добавить к нему Splash screen, иконки и задать цветовую схему приложения.

Результат, который должен получиться: [GitHub](https://github.com/it-shark-pro/mobile-citymap-xamarin/tree/part0) | [Zip](https://github.com/it-shark-pro/mobile-citymap-xamarin/archive/part0.zip)

**Полезные материалы:**

- [Создание приложения Xamarin.Android](https://docs.microsoft.com/ru-ru/xamarin/android/get-started/hello-android/hello-android-quickstart?tabs=vswin)
- [Создание приложения Xamarin.iOS](https://docs.microsoft.com/ru-ru/xamarin/ios/get-started/hello-ios/hello-ios-quickstart?tabs=vsmac)

- Android
  - [Полное руководство по Splash Screen на Android](https://habrahabr.ru/post/345380/)

- iOS
  - [Build a Basic UI](https://developer.apple.com/library/content/referencelibrary/GettingStarted/DevelopiOSAppsSwift/BuildABasicUI.html#//apple_ref/doc/uid/TP40015214-CH5-SW1)
  - [Icons and Images - iOS Human Interface Guidelines](https://developer.apple.com/ios/human-interface-guidelines/icons-and-images/image-size-and-resolution/)
  - [Understanding Auto Layout](https://developer.apple.com/library/content/documentation/UserExperience/Conceptual/AutolayoutPG/index.html#//apple_ref/doc/uid/TP40010853-CH7-SW1)

### Часть 1

Данное задание требует создать список элементов (не более 10) с открытием экрана с детальным описанием после нажатия на конкретным элемент списка.
Каждый элемент списка это объект класса (структуры) с некоторым набором атрибутов и методов. Объекты класса как и сам список создаются программно в рамках приложения.
Объект класса (структуры) должен содержать такие поля как `Name` и `Description`.

Результат, который должен получиться: [GitHub](https://github.com/it-shark-pro/mobile-citymap-xamarin/tree/part1) | [Zip](https://github.com/it-shark-pro/mobile-citymap-xamarin/archive/part1.zip)

**Полезные материалы:**
- [Пример результата 1](https://1drv.ms/i/s!At4OhPuAni8EhLMdETfFUnwSjuQCGg)
- [Пример результата 2](https://1drv.ms/i/s!At4OhPuAni8EhLMeXwWZ9yqw-qZFSg)

- Android
  - [Работа с ListView в Xamarin.Android](https://habrahabr.ru/post/301128/)
  - [Xamarin.Android - ListView](https://docs.microsoft.com/ru-ru/xamarin/android/user-interface/layouts/list-view/)
  - [Что такое Activity](http://developer.alexanderklimov.ru/android/theory/activity-theory.php)
  - [ListView](http://developer.alexanderklimov.ru/android/views/listview.php)

- iOS
  - [Работа с таблицами и ячейками](https://docs.microsoft.com/ru-ru/xamarin/ios/user-interface/controls/tables/)
  - [Create a Table View](https://developer.apple.com/library/content/referencelibrary/GettingStarted/DevelopiOSAppsSwift/CreateATableView.html#//apple_ref/doc/uid/TP40015214-CH8-SW1)
  - [Implement Navigation](https://developer.apple.com/library/content/referencelibrary/GettingStarted/DevelopiOSAppsSwift/ImplementNavigation.html#//apple_ref/doc/uid/TP40015214-CH16-SW1)
  - [Anatomy of Constraint](https://developer.apple.com/library/content/documentation/UserExperience/Conceptual/AutolayoutPG/AnatomyofaConstraint.html#//apple_ref/doc/uid/TP40010853-CH9-SW1)
  - [Working with Constraints in Interface Builder](https://developer.apple.com/library/content/documentation/UserExperience/Conceptual/AutolayoutPG/WorkingwithConstraintsinInterfaceBuidler.html#//apple_ref/doc/uid/TP40010853-CH10-SW1)

### Часть 2

В рамках данного задания требуется провести модификацию приложения полученного в [Часть 1 (Part 1)](#Часть-1) - заменить заданные вручную данные на полученные из сети в формате JSON.

Реализовать загрузку и отображение картинок (можно использовать сторонние библиотеки, к примеру [Xamarin.FFImageLoading](https://www.nuget.org/packages/Xamarin.FFImageLoading)) как для каждого элемента списка, так и в рамках экрана с детальным описанием.

Приложение должно проверять наличие интернет соединения и сообщать о его отсутствии при попытке сделать запрос в сеть для загрузки данных (для проверки соединения, можно использовать сторонние библиотеки, к примеру [Xam.Plugin.Connectivity](https://www.nuget.org/packages/Xam.Plugin.Connectivity)).

Ресурс для получения данных: https://api.myjson.com/bins/7ybe5

Результат, который должен получиться: [GitHub](https://github.com/it-shark-pro/mobile-citymap-xamarin/tree/part2) | [Zip](https://github.com/it-shark-pro/mobile-citymap-xamarin/archive/part2.zip)

**Полезные материалы:**
- [Пример результата 1](https://1drv.ms/i/s!At4OhPuAni8EhLMf8hTmYTqkEtAC7g)
- [Пример результата 2](https://1drv.ms/i/s!At4OhPuAni8EhLMhIOZDoHQHBhyEbA)
- [Пример результата 2](https://1drv.ms/i/s!At4OhPuAni8EhLMgwF5eDuEoORx6eQ)
- [Диспетчер пакетов NuGet](https://docs.microsoft.com/ru-ru/nuget/tools/package-manager-ui)
- [Асинхронное программирование с использованием ключевых слов Async и Await](https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/async/index)
- [Получение данных с сервера в json](https://metanit.com/sharp/xamarin/10.1.php)

- Android
  - [Xamarin.Android - RecyclerView](https://docs.microsoft.com/ru-ru/xamarin/android/user-interface/layouts/recycler-view/)
  - [RecyclerView](https://metanit.com/java/android/5.11.php)
  - [Оптимизация адаптера и View Holder](https://metanit.com/java/android/5.8.php)

- iOS
  - [Xamarin.iOS - Collection Views](https://developer.xamarin.com/guides/ios/user_interface/controls/uicollectionview/)
  - [Collection View - Tutorial](https://www.raywenderlich.com/136159/uicollectionview-tutorial-getting-started)

### Часть 3

В рамках данного задания требуется организовать работу с базой данных. Полученные данные в рамках [Часть 2 (Part 2)](#Часть-2) должны сохраняться в кэш (SQLite, файл, др.), а после, в ситуации с отсутствие интернет-соединения/ошибкой при загрузке данных из сети, доставаться из нее и отображаться пользователю (можно использовать сторонние библиотеки, к примеру [MonkeyCache](https://github.com/jamesmontemagno/monkey-cache)).

**Полезные материалы:**
- [Xamarin.Android - использование SQLite.NET](https://docs.microsoft.com/ru-ru/xamarin/android/data-cloud/data-access/using-sqlite-orm)
- [Xamarin.iOS - использование SQLite.NET](https://docs.microsoft.com/ru-ru/xamarin/ios/data-cloud/data/using-sqlite-orm)

Результат, который должен получиться: [GitHub](https://github.com/it-shark-pro/mobile-citymap-xamarin/tree/part3) | [Zip](https://github.com/it-shark-pro/mobile-citymap-xamarin/archive/part3.zip)

### Часть 4

В рамках данного задания требуется добавить отдельную страницу с картой, на которой будут отображены метки городов полученных из JSON координат.

**Полезные материалы:**
- [Пример результата 1](https://1drv.ms/i/s!At4OhPuAni8EhLMiuq3ivVrtLqXDdA)

- Android
  - [Xamarin Android: Create Xamarin Android Google Map With Add Markers](http://www.c-sharpcorner.com/article/xamarin-android-create-google-map-with-marker/)
  - [Google Maps API](https://docs.microsoft.com/ru-ru/xamarin/android/platform/maps-and-location/maps/maps-api)

- iOS
  - [Xamarin.iOS - Карты](https://docs.microsoft.com/ru-ru/xamarin/ios/user-interface/controls/ios-maps/)
  - [MapKit Tutorial](https://www.raywenderlich.com/160517/mapkit-tutorial-getting-started)

Результат, который должен получиться: [GitHub](https://github.com/it-shark-pro/mobile-citymap-xamarin/tree/part4) | [Zip](https://github.com/it-shark-pro/mobile-citymap-xamarin/archive/part4.zip)

### Результат

Финальный результат доступен в [master](https://github.com/it-shark-pro/mobile-citymap-xamarin) ветке и в качестве [Zip-архива](https://github.com/it-shark-pro/mobile-citymap-xamarin/archive/master.zip).

Реализацию с использованием [Xamarin.Forms](https://www.xamarin.com/forms) вы сможете найти в ветке [forms](https://github.com/it-shark-pro/mobile-citymap-xamarin/tree/forms) и в качестве [Zip-архива](https://github.com/it-shark-pro/mobile-citymap-xamarin/archive/forms.zip).

## Q & A

Если у Вас возникли какие-то вопросы или предложения, как улучшить материал - [дайте нам знать](https://github.com/it-shark-pro/mobile-citymap-xamarin/issues/new). :trophy: :+1:

## Другие варианты решения:
Дополнительно, Вы можете ознакомиться с реализацией данного приложения для каждой отдельной платформы, на нативных для этой платформы технологиях:
- [City Map - iOS - Swift](https://github.com/it-shark-pro/mobile-citymap-ios)
- [City Map - Android - Java](https://github.com/it-shark-pro/mobile-citymap-android)
- [City Map - Universal Windows Platform - C#](https://github.com/it-shark-pro/mobile-citymap-uwp)

> Так же, там содержится справочная информация, которая может дать более глубокое понимание конкретной платформы.
