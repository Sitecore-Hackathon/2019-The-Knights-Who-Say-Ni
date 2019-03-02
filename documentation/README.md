# Keyword Helper Field for Sitecore. Allows to see suggested keywords with search volume, CPC & competition data #

![Hackathon Logo](images/we-are-the-knights-who-say-ni.png?raw=true "We are the Knight Who Say NI!")

## Summary ##

**Category:**  Best enhancement to the Sitecore Admin (XP) UI for Content Editors & Marketers

This is a custom text field which provides Sitecore content managers and marketers with dynamic title and keyword suggestions along with insight into the Search Volume, Cost Per Cick (CPC) and Competiton for each suggested term  using free services by Google and keywordseverywhere.com so that they may be better able to optimize their content for SEO and ad campaign performance.

## Pre-requisites

- Sitecore 9.1
- You'll require a free Keywords Everywhere API key: https://keywordseverywhere.com/first-install-addon.html
- We shall require a shubbery... A NICE ONE!


## Installation

1. Use the Sitecore Installation Wizard to install the [KeywordFieldHelper package](https://github.com/Sitecore-Hackathon/2019-The-Knights-Who-Say-Ni/blob/master/sc.package/Knights.Foundation.KeywordFieldHelper.Master.update)


## Configuration

Enter your Keywords Everywhere API key in the "App_Config/Include/Foundation/KeywordFieldHelper/Knights.Foundation.KeywordFieldHelper.config file.

```xml

<sitecore>
    <settings>...
   
        <!-- You can get free API key here: https://keywordseverywhere.com/first-install-addon.html -->
        <setting name="KeywordsEverywhere.Api.Key" value="[YOUR_KEY_GOES_HERE]" />
        
        <!--
            Leave it empty for global ranking.
             
            Australia:      au
            Canada:         ca
            India:          in
            New Zealand:    nz
            South Africa:   za
            United Kingdom: uk
            United States:  us
        -->
        <setting name="KeywordsEverywhere.Api.Country" value="" />

        <!--
            Leave it empty for US dollar (by default). 
            Otherwise provide 3 letter ISO currency code lowercase.
            For example: eur, cad, gbp
        -->
        <setting name="KeywordsEverywhere.Api.Currency" value="" />
    </settings>
</sitecore>
```
If you would like implement your own keywords suggestions provider or keywords runking provider, just inherite appropriate interface and change service registration config:

```xml

<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
    <sitecore>
        <services>

            <register  serviceType="Knights.Foundation.KeywordFieldHelper.Services.IKeywordSuggestionsProvider, Knights.Foundation.KeywordFieldHelper"
                      implementationType="Knights.Foundation.KeywordFieldHelper.Services.GoogleKeywordSuggestionsProvider, Knights.Foundation.KeywordFieldHelper" />

            <register serviceType="Knights.Foundation.KeywordFieldHelper.Services.IKeywordRankingProvider, Knights.Foundation.KeywordFieldHelper"
                      implementationType="Knights.Foundation.KeywordFieldHelper.Services.KeywordsEverywhereKeywordRankingProvider, Knights.Foundation.KeywordFieldHelper" />
        </services>
    </sitecore>
</configuration>

```

## Usage

1. First you need to go to Sitecore Update Wizard and install the package.

2. Configure API key (see **Configuration Section**)

3. We suggest to create a base template with Page Metadata fields such as Page Title, Page Description and inherite this template to use across all your pages. **Keyword Helper Text** is a custom Simple Type and a perfect candidate for a Page Title field. It brings the power of SEO relevant keywords right to the Sitecore Content Editor.
![Hackathon Logo](images/template.png?raw=true "Template with Keyword Helper Text field type")

4. Once you start entering the text, **Keyword Helper** will suggest you with relevant keywords ranked by volume of monthly requests, costs per click and competition value;
![Hackathon Logo](images/suggestions.png?raw=true "Keyword Helper Text showing suggestions")

5. If you are not editing the field, it's going to show you ranking information for the current value.
![Hackathon Logo](images/ranking.png?raw=true "Keyword Helper Text showing suggestions")


## Video

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
