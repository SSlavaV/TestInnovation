### Предполагаемая схема работы

[WorkScheme](/Innovation.png)

###Тестовое задание
Настроить строку подключения в appsettings.json опция DefaultConnection
Запустить сервис
Перейти на [swagger](swagger/index.html) 
Зарегистрировать [Регион](/api/Region/create)
Зарегистрировать [Устройство](/api/Device/create)
Получить [код авторизации](/api/Login/login)
Добавить его в headers запросов Authorization: Bearer eyJhbGciO....
Зарегистрировать [событие](/api/Device/registerEvent)
Получить [список событий](/api/Device/getevents)

