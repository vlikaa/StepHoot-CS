﻿

/////////////////////////////////////////////////////////////////////////////////
///
///     прога работает на костылях, просьба не ломать ее, а то сломается
///
///     оценил бы ее на проходной балл, ибо много недоработок
///
///     возможно когда-нибудь пересдам
///
///     ! еще при создание нового User-a(то есть метод Registration), обратите внимаю на валидацию,
///
///     она есть, но никак не обрабатывается, вводите все корректно чтоб прога не легла
///
///     Name - С заглавной буквы от 3-х букв
///     Surname - С заглавной буквы от 4-х букв
///     Phone - только цифры, количество цифор должно быть равно 10
///     Login - логин не должен содержать символы кроме "_", длина от 6
///     Password - не должен содержать Name или Login, длина от 8
/// 
/////////////////////////////////////////////////////////////////////////////////
///               ///
/// Login: admin  ///
/// Pass: admin   ///
///               ///
/////////////////////

using StepHoot_C_;

var stepHoot = new StepHoot();


GameRule.Start(stepHoot);
