![](http://www.sebahattinonurozler.com/wp-content/uploads/2019/06/sa.gif)
# VCAR
Turkish and English Voice Controlled, Augmented Reality Car Showroom Application. Inspired by Diego Herrera courses.

### Features

Cars :
- Audi R8
- Lamborghini Gallordo

Can use Commands by clicking microphone button.

Commands : 
- Open/Close Car Door
- Show/Close Car Information
- Change Car Color


Made with:
- Unity
- Vuforia (Augmented Reality SDK)
- Wit.ai (NLP, used for Command Control)

## Media & Download Link

[Google Play](https://play.google.com/store/apps/details?id=com.OnurOzler.VCAR) 

[Turkish App Test](https://www.youtube.com/watch?v=w14ustv_jkw)

[English App Test](https://youtu.be/L3s-YnNE4N8)

## How to Use
It is made with Unity Version : 2019.1.3f1, recommend you to use exactly this version. Need to do some configurations.

+ Vuforia Configuration

  + For using AR features, need to have Vuforia Key. [Get Vuforia Key](https://library.vuforia.com/articles/Training/Vuforia-License-Manager)

  + Paste Your Key in VuforiaConfiguration, App License Key:
  ![](http://www.sebahattinonurozler.com/wp-content/uploads/2019/06/getKey.png)

+ Wit.ai Configuration

  + Create Wit.ai Account
  
  + Create New App in Wit.ai for every Language
  
  + Train your bot depending on Entities (Commands) [Quick Start for Wit.ai](https://wit.ai/docs/quickstart)
  
  + Take your token in settings of your app, and paste it to _Handle.cs
  ![](http://www.sebahattinonurozler.com/wp-content/uploads/2019/06/api.png)
  
  + In this app, entities are the commands I mentioned above. You can add new entities and train your bot. You need to add new entities _Handle.cs in Entities Class.
  
    ![](http://www.sebahattinonurozler.com/wp-content/uploads/2019/06/apiEntitySection.png)
