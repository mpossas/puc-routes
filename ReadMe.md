# Pre-protocolo
Execute os comandos contidos no arquivo install-dependencies

# Como depurar

### Browser
Na pasta raiz do projeto execute:

$ npm run serve

### Android
**Requer a instalacao do Android Sdk**
Na pasta raiz do projeto execute:

$ gulp debug
$ ionic cordova build android
Execute o arquivo .apk no emulador

### iOS
**Requer o Xcode**

$ sudo gulp debug
$ sudo ionic cordova build ios
Abra o projeto gerado em platform/ios no Xcode
Execute o projeto no simulador

# Como exportar para a loja

### Android
**Requer a instalacao do Android Sdk**

$ npm run release
$ cd platforms\android\app\build\outputs\apk\release
$ jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore "C:\Projetos\OneAPP\chaves\One Beleza.key" app-release-unsigned.apk "ONE Beleza & Bem-estar"
$ 204c96J+FP0>sxP
$ 204c96J+FP0>sxS
$ del one.apk
$ C:\Users\Outros\AppData\Local\Android\Sdk\build-tools\28.0.3\zipalign.exe -v 4 app-release-unsigned.apk one.apk

### iOS
**Requer o Xcode**
Abra o arquivo platforms/ios/cordova/build-release.xcconfig e altere CODE_SIGN_IDENTITY e CODE_SIGN_IDENTITY[sdk=iphoneos*] para iPhone Developer

$ sudo gulp release
$ sudo ionic cordova build ios

Abra o projeto gerado (platform/ios) no Xcode
Clique no arquivo Beleza.xcodeproj e em `Signing` selecione um time de desenvolvimento
No menu `Product`, selecione `Archive`

### Passos da publicacao
Altere no arquivo config.xml as propriedades android-versionCode (200500000 -> 200500010) e version (2.5.0 -> 2.5.1) da tag `widget`