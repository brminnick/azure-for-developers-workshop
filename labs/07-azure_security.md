# Azure Security

## 1. Microsoft Learn Security Module

1. Click this link to navigate to the Microsoft Learn Security Module: 
    - [**Top 5 security items to consider before pushing to production**](https://docs.microsoft.com/learn/modules/top-5-security-items-to-consider/?WT.mc_id=TechBash-github-bramin)

2. (Optional) On the **Microsoft Learn** page, sign into your Azure account
    - [Microsoft Learn](https://docs.microsoft.com/learn/?WT.mc_id=TechBash-github-bramin) offers badges and points for completing modules

3. On the **Microsoft Learn** page, select **Start**
4. Complete the security module

## 2. Azure Security Center

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. On the Azure Portal, on the left-hand menu, select **Al services**
3. In the **All services** window, in the **Filter** bar at the top, type **Security**
4. In the **All services** window, select **Security Center**
5. In  **Security Center** on the left hand menu, select **Recommendations**
6. Let's walk through some of the recommendations together

## 3. Enable App Service Managed Service Identity

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. On the Azure Portal, navigate to your App Service resource
3. On the App Service Overview page, on the left-hand menu, select **Managed service identity**
4. On the **Managed service identity** page, select **On**
5. On the **Managed service identity** page, select **Save**

## 4. Create Azure Key Vault Resource

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. In the Azure Portal, select **+Create a Resource**
3. In the **New** window, type **Key Vault** into the search bar
4. From the search results, select **Key Vault**
5. On the **Key Vault** page, select **Create**
6. On the **Create key vault** page, create a unique key vault name for **Name:**
7. On the **Create key vault** page, select your Azure subscription
8. On the **Create key vault** page, select the location closest to you 
9. On the **Create key vault** page,  **Pricing Tier:** Standard
10. On the **Create key vault** page, select **Access policies**
11. On the **Access policies** page, select **+ Add new**
12. On the **Add new policy** page, select **Select principal**
13. In the **Principal** page, enter the name of your app service in the search bar
14. In the **Principal** page, select your app service
15. In the **Principal** page, click **Select**
16. On the **Add new policy** page, add the following **Secret Permissions**:
    - **Note:** Ensure you are modifying **Secret Permissions**, not Key or Certificate permissions
    - **Get**
    - **List**
17. On the **Add new policy** page, select **Ok**
18. On the **Access policies** page, select **Ok**
19. On the **Create key vault page**, select **Create**
20. On the Azure Portal, select the bell-shaped notification icon
21. Stand by while the Notifications window says **Deployment in progress...**
22. Once the deployment has finished, on the Notifications window, select **Go to resource**

## 5. Add Cognitive Services Secrets to Key Vault

1. On the **Key Vault** resource page, select **Secrets**
2. On the **Secrets** page, select **+ Generate/Import**
3. On the **Create a secret** page, make the following selections:
    - **Upload options**: Manual
    - **Name:** TextAnalyticsBaseUrl
    - **Value:** [Your Text Analytics Base Url]
        - E.g. "https://westus.api.cognitive.microsoft.com"
    - **Content type:** [Leave blank]
    - **Set activation date?** [Unchecked]
    - **Set expiration date?** [Unchecked]
    - **Enabled?** Yes
4. On the **Create a secret** page, select **Create**
5. On the **Secrets** page, select **+ Generate/Import**
6. On the **Create a secret** page, make the following selections:
    - **Upload options**: Manual
    - **Name:** TextAnalyticsApiKey
    - **Value:** [Your Text Analytics Api Key]
    - **Content type:** [Leave blank]
    - **Set activation date?** [Unchecked]
    - **Set expiration date?** [Unchecked]
    - **Enabled?** Yes
7. On the **Create a secret** page, select **Create**
8. On the **Key Vault** resource page, select **Overview**
9. On the **Key Vault Overview** page, locate the **DNS name**
10. Copy down the value of **DNS name**. We will use it to connect our Key Vault to our App Service

## 6. Add Key Vault Endpoint to App Service

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. On the Azure Portal, navigate to your App Service resource
3. On the **App Services Overview** page, on the left-hand menu, select **Application settings**
4. In **Application settings**, scroll down to the **Application settings** section
5. In the **Application settings** section, select **+ Add new setting**
6. In the **+ Add new setting** section, Enter the following values:
    - **Enter a name:** KeyVaultEndpoint
    - **Enter a value:** [Your Azure Key Vault DNS name]
7. On the **Application settings** page, select **Save**

## 7. Remove TextAnalytics Data from App Settings

1. In the hotelsweb solution, open `appsettings.json`
2. In `appsettings.json`, remove the value of `TextAnalyticsApiKey` leaving it as an empty string
    - E.g. `"TextAnalyticsApiKey": "",`
3. In `appsettings.json`, remove the value of `TextAnalyticsBaseUrl` leaving it as an empty string
    - E.g. `"TextAnalyticsBaseUrl": "",`
4. In the hotelsweb solution, open `appsettings.Development.json`
5. In `appsettings.Development.json`, remove the value of `TextAnalyticsApiKey` leaving it as an empty string
    - E.g. `"TextAnalyticsApiKey": "",`
6. In `appsettings.Development.json`, , remove the value of `TextAnalyticsBaseUrl` leaving it as an empty string
    - E.g. `"TextAnalyticsBaseUrl": "",`

## 8. Verify Sentiment Analysis (Azure)

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