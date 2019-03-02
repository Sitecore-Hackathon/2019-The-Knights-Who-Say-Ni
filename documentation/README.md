# Keyword Helper Field for Sitecore  #

![Hackathon Logo](images/we-are-the-knights-who-say-ni.png?raw=true "We are the Knight Who Say NI!")

## Summary ##

**Category:**  Best enhancement to the Sitecore Admin (XP) UI for Content Editors & Marketers

This is a custom text field which provides Sitecore content managers and marketers with dynamic title and keyword suggestions along with insight into the Search Volume, Cost Per Cick (CPC) and Competiton for each suggested term  using free services by Google and keywordseverywhere.com so that they may be better able to optimize their content for SEO and ad campaign performance.

## Pre-requisites

- Sitecore 9.1
- You'll require a free Keywords Everywhere API key: https://keywordseverywhere.com/first-install-addon.html


## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1. Use the Sitecore Installation wizard to install the [KeywordFieldHelper package](#link-to-package)


## Configuration

Enter your Keywords Everywhere API key in the "App_Config/Include/Feature/KeywordFieldHelper/Knights.Feature.KeywordFieldHelper.config file.

```xml

<sitecore>
    <settings>...
   
        <!-- You can get free API key here: https://keywordseverywhere.com/first-install-addon.html -->
        <setting name="KeywordsEverywhere.Api.Key" value="[YOUR_KEY_GOES_HERE]" />
    </settings>
</sitecore>
```

## Usage

Provide documentation  about your module, how do the users use your module, where are things located, what do icons mean, are there any secret shortcuts etc.

Please include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:


## Video

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
