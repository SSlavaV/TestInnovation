### Предполагаемая схема работы

![WorkScheme](/Innovation.png)

### Тестовое задание
1. Настроить строку подключения в appsettings.json опция DefaultConnection
2. Запустить сервис
3. Перейти на [swagger](swagger/index.html) 
4. Зарегистрировать [Регион](/api/Region/create)
5. Зарегистрировать [Устройство](/api/Device/create)
6. Получить [код авторизации](/api/Login/login)
7. Добавить его в headers запросов Authorization: Bearer eyJhbGciO....
8. Зарегистрировать [событие](/api/Device/registerEvent)
9. Получить [список событий](/api/Device/getevents)

