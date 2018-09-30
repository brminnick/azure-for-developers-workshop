# Cognitive Services

## 1. Create Azure TextAnalytics Resource

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
   - If you are new to Azure, [use this sign-up link](https://azure.microsoft.com/free/ai/?WT.mc_id=TechBash-github-bramin) to receive a free $200 credit
2. On the Azure Portal, select **+Create a Resource**
3. In the **New** window, select **AI + Machine Learning**
4. In the **Featured** frame, select **Text Analytics**
5. In the **Create** window, make the following selections
    - **Name:** [Create a unique resource name]
    - **Subscription:** [Select your Azure subscription]
    - **Location:** [Select the location closest to you]
    - **Pricing Tier:** F0 (5K Transactions per 30 days)
        - This is a free tier
    - **Resource Group:** [Create a unique resource group name]
6. In the **Create** window, select **Create**
7. On the Azure Portal, select the bell-shaped notification icon
8. Stand by while the Notifications window says **Deployment in progress...**
9. Once the deployment has finished, on the Notifications window, select **Go to resource**
10. On the **Resource** page, select **Keys**
11. On the Keys page, locate **KEY 1**
    - We will use this API Key in our app
12. In the Resource page, select **Overview**
13. On the **Overview** page, locate the **Endpoint**
    - We will use this Url in our app

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
   - Example neutral review: "This is a big hotel"

10. On the Review page, ensure that a neutral emoji appears