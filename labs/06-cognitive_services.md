# Cognitive Services

## 1. Create Azure TextAnalytics Resource

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. On the Azure Portal, select **+Create a Resource**
3. In the **New** window, select **AI + Machine Learning**
4. In the **Featured** frame, select **Text Analytics**

![Create Resource](https://user-images.githubusercontent.com/13558917/46328127-651d7200-c5d3-11e8-92dd-cc51cecb856c.png)

5. In the **Create** window, make the following selections
    - **Name:** [Create a unique resource name]
    - **Subscription:** [Select your Azure subscription]
    - **Location:** [Select the location closest to you]
    - **Pricing Tier:** F0 (5K Transactions per 30 days)
        - This is a free tier
    - **Resource Group:** [Create a unique resource group name]
6. In the **Create** window, select **Create**

![Create Text Analytics](https://user-images.githubusercontent.com/13558917/46328126-651d7200-c5d3-11e8-8855-f781b19dce90.png)

7. On the Azure Portal, select the bell-shaped notification icon
8. Stand by while the Notifications window says **Deployment in progress...**
9. Once the deployment has finished, on the Notifications window, select **Go to resource**

![Go to resource](https://user-images.githubusercontent.com/13558917/46328174-aca3fe00-c5d3-11e8-9571-36f2f7281f14.png)

10. On the **Resource** page, select **Keys**
11. On the Keys page, locate **KEY 1**
    - We will use this API Key in our app

![Api Keys](https://user-images.githubusercontent.com/13558917/46328125-651d7200-c5d3-11e8-99a6-94c0a16af2bd.png)

12. In the Resource page, select **Overview**
13. On the **Overview** page, locate the **Endpoint**
    - We will use this Url in our app

![Endpoint](https://user-images.githubusercontent.com/13558917/46328124-651d7200-c5d3-11e8-8641-927143e26535.png)

## 2. Add TextAnalytics Data to App Settings

1. In the hotelsweb solution, open `appsettings.json`
2. In `appsettings.json`, enter the value of your TextAnalytics API key for `TextAnalyticsApiKey`
    - E.g. `"TextAnalyticsApiKey": "[Your Api Key]",`
3. In `appsettings.json`, enter the value of your TextAnalytics API Base url for `TextAnalyticsBaseUrl`
    - E.g. `"TextAnalyticsBaseUrl": "https://westus.api.cognitive.microsoft.com",`
    - **Note:** Do not enter the full url of the API endpoint; only provide the base url.
4. In the hotelsweb solution, open `appsettings.Development.json`
5. In `appsettings.Development.json`, enter the value of your TextAnalytics API key for `TextAnalyticsApiKey`
    - E.g. `"TextAnalyticsApiKey": "[Your Api Key]",`
6. In `appsettings.Development.json`, enter the value of your TextAnalytics API Base url for `TextAnalyticsBaseUrl`
    - E.g. `"TextAnalyticsBaseUrl": "https://westus.api.cognitive.microsoft.com",`
    - **Note:** Do not enter the full url of the API endpoint; only provide the base url.

## 3. Verify Sentiment Analysis (Local)

1. Build/Deploy `hotelsweb.csproj` locally
2. On the Hotels360 website, click **Reviews** from the top menu
3. On the Reviews page, enter a positive review
   - Example positive review: "Best hotel ever!"
4. On the Review page, ensure that a happy emoji appears
5. On the Hotels360 website, click **Reviews** from the top menu
6. On the Reviews page, enter a negative review
   - Example negative review: "Terrible hotel. Will never stay here again!"
7. On the Review page, ensure that a sad emoji appears
8. On the Hotels360 website, click **Reviews** from the top menu
9. On the Reviews page, enter a neutral review
   - Example neutral review: "This is a big hotel"
10. On the Review page, ensure that a neutral emoji appears

## 4. Verify Sentiment Analysis (Azure)

1. Build/Deploy `hotelsweb.csproj` to the Azure Web App instance created earlier
2. On the Hotels360 website, click **Reviews** from the top menu
3. On the Reviews page, enter a positive review
   - Example positive review: "Best hotel ever!"
4. On the Review page, ensure that a happy emoji appears
5. On the Hotels360 website, click **Reviews** from the top menu
6. On the Reviews page, enter a negative review
   - Example negative review: "Terrible hotel. Will never stay here again!"
7. On the Review page, ensure that a sad emoji appears
8. On the Hotels360 website, click **Reviews** from the top menu
9. On the Reviews page, enter a neutral review
   - Example neutral review: "This is a big hotel"]
10. On the Review page, ensure that a neutral emoji appears