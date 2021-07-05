<?php
    // при запросе без параметров (при запуске)
    if(!isset($_POST['fileName'])) {
        $files = '';
        // открываем директорию (заменить путь при скачивании)
        $dir = opendir('C:\xampp\htdocs\scripts\KR');
        $pattern = '/^((?!_r).)*$/';

        // читаем имя очередного файла из директории, пока она не пуста
        while (($fileName = readdir($dir)) !== false){
            // если текстовый файл не результат предыдущей работы
            if (preg_match($pattern, $fileName) &&  preg_match('/txt$/',$fileName))
                // конкатенация имен найденных файлов без расширения через разделитель :
                $files = $files . substr($fileName,0,-4) . ':';
        }
        // вывод без последнего разделителя
        echo substr($files,0,-1);// отправляет строку для значений cmb

    } else {
        $filename = $_POST['fileName'];
        // входной и результирующие файлы
        $fin = fopen($filename . '.txt', 'r');
        $fout = fopen($filename . '_r.txt', 'w+');

        // построчное чтение входного файла и запись транслитерации в результирующий
        while (!feof($fin)) {
            $str = fgets($fin);
            $transliteration = getTransliteration($str);
            fwrite($fout, $transliteration);
        }

        // чтение файлов
        $input = file_get_contents($filename.'.txt');
        $output = file_get_contents($filename.'_r.txt');
        // закрытие файлов
        fclose($fin);
        fclose($fout);
        // создание лога
        makeLog($filename.'.txt');
        // отправка содержимого входного и результирующего файлов с разделителем ::
        echo $input.'::'.$output;
    }

    // возвращает транслитированную строку
    function getTransliteration($str)
    {
        // словарь транслитераций
        $dictionary = [
            'а' => 'a',        'б' => 'b',        'в' => 'v',
            'г' => 'g',        'д' => 'd',        'е' => 'e',
            'ё' => 'e',        'ж' => 'j',        'з' => 'z',
            'и' => 'i',        'й' => 'i',        'к' => 'k',
            'л' => 'l',        'м' => 'm',        'н' => 'n',
            'о' => 'o',        'п' => 'p',        'р' => 'r',
            'с' => 's',        'т' => 't',        'у' => 'u',
            'ф' => 'f',        'х' => 'h',        'ц' => 'c',
            'ч' => 'ch',       'ш' => 'sh',       'щ' => 'sc',
            'ы' => 'y',        'ь' => '\'',       'ъ' => '\'',
            'э' => 'e',        'ю' => 'iu',       'я' => 'ia',
            'А' => 'A',   'Б' => 'B',   'В' => 'V',
            'Г' => 'G',   'Д' => 'D',   'Е' => 'E',
            'Ё' => 'E',   'Ж' => 'J',   'З' => 'Z',
            'И' => 'I',   'Й' => 'I',   'К' => 'K',
            'Л' => 'L',   'М' => 'M',   'Н' => 'N',
            'О' => 'O',   'П' => 'P',   'Р' => 'R',
            'С' => 'S',   'Т' => 'T',   'У' => 'U',
            'Ф' => 'F',   'Х' => 'H',   'Ц' => 'C',
            'Ч' => 'Ch',  'Ш' => 'Sh',  'Щ' => 'Sc',
            'Ь' => '\'',  'Ы' => 'Y',   'Ъ' => '\'',
            'Э' => 'E',   'Ю' => 'Iu',  'Я' => 'Ia'
        ];

        // разбивает на символы исходную строку
        $symbols = preg_split('//u', $str, -1, PREG_SPLIT_NO_EMPTY);
        // результирующая строка
        $transliterationOfStr = '';
        foreach ($symbols as $symbol) {
            // если буква из кириллицы
            if (preg_match('/[А-Яа-яЁё]/iu', $symbol)) {
                // замена буквы на транслитерацию из словаря
                $newSymbol = $dictionary[$symbol];
            } else {
                $newSymbol = $symbol;
            }
            $transliterationOfStr = $transliterationOfStr . $newSymbol;
        }
        return ($transliterationOfStr);
    }

    // создание лога в бд
    function makeLog($filename){
        // парметры для подключения к бд (заменить при скачивании)
        $hostname_Database = '127.0.0.1';
        $database_Database = 'KR';
        $username_Database = 'root';
        $password_Database = '';

        // подключение к бд
        $mysqli = new mysqli($hostname_Database, $username_Database, $password_Database, $database_Database);
        // взятие ip
        $ip = $_SERVER['REMOTE_ADDR'];
        // даты
        $date = date('Y-m-d H:i:s');//получаем дату
        // insert-запрос
        $query = "INSERT INTO `KR`.`logs`
           (`ip`, `filename`, `time`)
           VALUES ('$ip', '" . $filename . "', '" . $date . "')";
        $mysqli->query($query);
    }
?>