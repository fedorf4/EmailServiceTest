# EmailServiceTest

## Для включения в конфигурацию логина и пароля
1. ПКМ по решению -> Управление секретами пользователя (Manage user secrets)
2. Задаём структуру секретов:
```json
  {  
    "e-mail-login": "example@mail.ru",  
    "e-mail-password": "sTrongPass2ex@"  
  }  
```
Проект тестирование почтового сервиса e.mail.ru с использованием Selenium
Включает в себя:
  - Базовые тесты: ✔️
    1. авторизации ✔️
    2. отправки сообщения ✔️
  - Тесты настроек:  
    - Внешний вид:  
      1. смена темы на темную/светлую
      2. компактный вид почты
    - Умная сортировка
      1. отключение на боковой панели планок "Госписьма" и т.п.
  - Все настройки 
    - Лог действий
      - проверка логирования поледних действий
    - Папки
      - проверка добавления новой папки и ее отображения на странице
    - Общие
      - добавление подписи и ее отображение
      - удаление подписи
  - Тесты производительности:  
    - Замер скорости отдачи html-страницы по GET запросу на https://www.e.mail.ru/
    - UI замер скорости прогрузки:  
      1. Скорость от логирования до написания письма
      2. Скорость проверки последних действий на аккаунте 
