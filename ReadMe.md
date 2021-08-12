# 运行环境 

## Windows

cmd

### E:

cd E:\My Work\iClinic2016\iClinicDevelop\branches\bitbucket\HomeWork.HCX\homework_api\bin\Debug\net5.0

homework_api.exe

![image-20210813004130585](ReadMe.Image\image-20210813004130585.png)

![image-20210813020012471](ReadMe.Image\image-20210813020012471.png)

## Docker

目前能只通过 Visual Studio 2019 运行在Docker Desktop

# 功能说明

## 初始化

### 程序启动已经有初始着陆坐标 

```json
{
  "face": "E",
  "x": "B",
  "y": 10
}
```

(向东，X=B ,Y=10 )

## 重新初始化

接口 /Operation/Init

参数

```json
{
  "face": "S",
  "x": "P",
  "y": 15
}
```

(向南，X=P,Y=15)

## 询问当前位置

/Operation/GetLocation

## 执行批量指令

```
/Operation/Run?pCommands=FFFFFFBBHFFFFFFRFFFFF
```

## 显示当前状态与搜索记录并绘图

/Operation/Show

![image-20210813021855274](ReadMe.Image\image-20210813021855274.png)

```json
{
  "location": {
    "face": "S",
    "x": "L",
    "y": 15
  },
  "pathway": [
    {
      "command": "S",
      "location": {
        "face": "E",
        "x": "B",
        "y": 10
      },
      "message": "Landing completed",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "C",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "D",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "E",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "F",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "G",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "H",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "B",
      "location": {
        "face": "E",
        "x": "G",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "B",
      "location": {
        "face": "E",
        "x": "F",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "H",
      "location": {
        "face": "E",
        "x": "F",
        "y": 10
      },
      "message": "invalid",
      "expand": [
        {
          "face": "E",
          "x": "E",
          "y": 9
        },
        {
          "face": "E",
          "x": "F",
          "y": 9
        },
        {
          "face": "E",
          "x": "G",
          "y": 9
        },
        {
          "face": "E",
          "x": "E",
          "y": 10
        },
        {
          "face": "E",
          "x": "G",
          "y": 10
        },
        {
          "face": "E",
          "x": "E",
          "y": 11
        },
        {
          "face": "E",
          "x": "F",
          "y": 11
        },
        {
          "face": "E",
          "x": "G",
          "y": 11
        }
      ]
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "G",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "H",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "I",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "J",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "K",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "E",
        "x": "L",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "R",
      "location": {
        "face": "S",
        "x": "L",
        "y": 10
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "S",
        "x": "L",
        "y": 11
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "S",
        "x": "L",
        "y": 12
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "S",
        "x": "L",
        "y": 13
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "S",
        "x": "L",
        "y": 14
      },
      "message": "success",
      "expand": []
    },
    {
      "command": "F",
      "location": {
        "face": "S",
        "x": "L",
        "y": 15
      },
      "message": "success",
      "expand": []
    }
  ],
  "picture": [
    "  ABCDEFGHIJKLMNOPQRSTUVWXY",
    "01_________________________",
    "02_________________________",
    "03_________________________",
    "04_________________________",
    "05_________________________",
    "06_________________________",
    "07_________________________",
    "08_________________________",
    "09____XXX__________________",
    "10_→→→X→→→→→→↓_____________",
    "11____XXX____↓_____________",
    "12___________↓_____________",
    "13___________↓_____________",
    "14___________↓_____________",
    "15___________↓_____________",
    "16_________________________",
    "17_________________________",
    "18_________________________",
    "19_________________________",
    "20_________________________",
    "21_________________________",
    "22_________________________",
    "23_________________________",
    "24_________________________",
    "25_________________________"
  ]
}
```

# 注意事项

## 1)  执行指令只支持大写字母（F，B，R，L，H）,小写字母与其它字母无法识别。

## 2）Face（朝向）字段，只支持大写字母（E，S，W，N）,小写字母与其它字母无法识别。

## 3)  X 坐标字段，只支持大写字母，小写字母与其它字母无法识别。

