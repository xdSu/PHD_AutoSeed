PHD_AutoSeed
============

PHD_AutoSeed

功能极其简单的PHD_AutoSeed的极其啰嗦的使用说明

1.把PHD_AutoSeed.exe、transmission-create.exe和config.ini一共三个文件放到一个文件夹中，注意，路径中不能有中文。
2.猛击PHD_AutoSeed.exe（以下简称P），右下角会出现一个P，此时发种程序就开始运行了，第一次运行我们要手动修改一些配置。
3.右击那个P，三个选项为Settings、Pause和Quit，点Pause将暂停，点Quit将退出，下面重点介绍Settings。
  c_secure_uid
  c_secure_login
  c_secure_pass
  这几个是登陆网站的cookies，默认是AutoSeed这个账号，可以改成自己的（推荐使用Chrome插件EditThisCookies可以轻松获得）
  anonymous 勾上就匿名发布
  website 就填主站的网址，要加http，目前是http://pt.phdbits.net
  Watch Folder 监视用的文件夹，将压制好的成品文件夹放进去，然后改名加上===DONE的的后缀，P会立刻将文件夹改回原名并生成同名文件 xxx.STATUS供查看发种状态，完毕后该STATUS文件会删除，该文件夹会被移动至做种目录。
  Torrents Folder PT下载工具的种子监视目录，P会将自动发布的种子下载到该目录供PT程序做种。
  Download Folder 做种目录，即PT程序的默认下载目录，P会在种子发布后前将要发布的文件夹移动过来，等种子下载之后PT程序即可进行校验随后做种。
  
  ReLoad可以在手误点错东西之后重读配置文件
  Save可以保存配置，P会立刻重新读取配置开始工作
