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
    - авторизации ✔️
    - отправки сообщения ✔️
  - Тесты настроек:  
    - Внешний вид:  
      - смена темы на темную/светлую ✔️
      - компактный вид почты ✔️
    - Умная сортировка
      - отключение на боковой панели планок "Госписьма" и т.п. ✔️
  - Все настройки 
    - Лог действий
      - проверка логирования поледних действий✔️
    - Папки
      - проверка добавления новой папки и ее отображения на странице ✔️
    - Общие
      - добавление подписи и ее отображение при написании письма ✔️
      - удаление подписи ✔️
  - Тесты производительности:  
    - Замер скорости отдачи html-страницы по GET запросу на https://www.e.mail.ru/ ✔️
    - UI замер скорости прогрузки:  
      - Скорость от логирования до написания письма ✔️
      - Скорость проверки последних действий на аккаунте ✔️
      
