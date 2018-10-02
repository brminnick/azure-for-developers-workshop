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

![All Resources, Security Center](https://user-images.githubusercontent.com/13558917/46313382-bc9ced00-c595-11e8-8cb7-73f0d9a44fdc.png)

5. In  **Security Center** on the left hand menu, select **Recommendations**
6. Let's walk through some of the recommendations together

![Security Center Recommendations](https://user-images.githubusercontent.com/13558917/46313383-bc9ced00-c595-11e8-9ee0-0e612d04fedb.png)

## 3. Enable App Service Managed Service Identity

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. On the Azure Portal, navigate to your App Service resource
3. On the App Service Overview page, on the left-hand menu, select **Managed service identity**
4. On the **Managed service identity** page, select **On**
5. On the **Managed service identity** page, select **Save**

![Manages Service Identity, App Service](https://user-images.githubusercontent.com/13558917/46313381-bc9ced00-c595-11e8-9bd7-cd2aecbb18e5.png)

## 4. Create Azure Key Vault Resource

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. In the Azure Portal, select **+Create a Resource**
3. In the **New** window, type **Key Vault** into the search bar

![Key Vault Search](https://user-images.githubusercontent.com/13558917/46315668-08529500-c59c-11e8-95fd-33a90665ace7.png)

4. From the search results, select **Key Vault**
5. On the **Key Vault** page, select **Create**

![Create Key Vault Resource](https://user-images.githubusercontent.com/13558917/46315676-08eb2b80-c59c-11e8-8108-44100f45a54e.png)

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

![Add Principal](https://user-images.githubusercontent.com/13558917/46315675-08eb2b80-c59c-11e8-8854-838b8a2efc34.png)

16. On the **Add new policy** page, add the following **Secret Permissions**:
    - **Note:** Ensure you are modifying **Secret Permissions**, not Key or Certificate permissions
    - **Get**
    - **List**
17. On the **Add new policy** page, select **Ok**
18. On the **Access policies** page, select **Ok**
19. On the **Create key vault page**, select **Create**

![Create Key Vault](https://user-images.githubusercontent.com/13558917/46315672-08529500-c59c-11e8-9071-62d4be8ac41f.png)

20. On the Azure Portal, select the bell-shaped notification icon
21. Stand by while the Notifications window says **Deployment in progress...**
22. Once the deployment has finished, on the Notifications window, select **Go to resource**

![Go To Resource](https://user-images.githubusercontent.com/13558917/46316001-eb6a9180-c59c-11e8-99f3-1efee0712433.png)

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

![Create Base Url Secret](https://user-images.githubusercontent.com/13558917/46315671-08529500-c59c-11e8-8c5c-087b7c6df0c2.png)

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

![Create Api Key Secret](https://user-images.githubusercontent.com/13558917/46315670-08529500-c59c-11e8-8d74-2c2627e0e2c8.png)

8. On the **Key Vault** resource page, select **Overview**
9. On the **Key Vault Overview** page, locate the **DNS name**
10. Copy down the value of **DNS name**. We will use it to connect our Key Vault to our App Service

![Key Vault DNS Name](https://user-images.githubusercontent.com/13558917/46315669-08529500-c59c-11e8-91c5-446704e0f592.png)

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

![Add Application Settings](https://user-images.githubusercontent.com/13558917/46316412-1d302800-c59e-11e8-8eb8-796ea9f554c5.png)

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

## 9. Add Authentication

1. Navigate to the [Azure Portal](https://portal.azure.com/?WT.mc_id=TechBash-github-bramin)
2. On the Azure Portal, navigate to your App Service resource
3. On the **App Services Overview** page, locate the App Service URL
    - We will use this URL later

![App Service Url](https://user-images.githubusercontent.com/13558917/46318766-9aab6680-c5a5-11e8-9a98-b7d332124cb5.png)

4. On the **App Services Overview** page, on the left-hand menu, select **Authentication / Authorization**
5. On the **Authentication / Authorization** page, make the following selections:
    - **App Service Authentication**: On
    - **Action to take when request is not authenticated**: Log in with Microsoft Account
6. On the On the **Authentication / Authorization** page, select **Save**

![Microsoft Auth Settings](https://user-images.githubusercontent.com/13558917/46318829-c595ba80-c5a5-11e8-9503-f389ce0ffbc0.png)

7. On the **Authentication / Authorization** page, select **Microsoft Not Configured**
8. On the **Microsoft Account Authentication Settings** page, click **Tese settings allow users to sign in with Microsoft Account. Click here to learn more.**

![Microsoft App Setup](https://user-images.githubusercontent.com/13558917/46318735-85ced300-c5a5-11e8-9f5b-dd365f0b5ee3.png)

9. On the **How to configure your App Service application to use Microsoft Account login** page, click **[My Applications]

![My Application](https://user-images.githubusercontent.com/13558917/46318734-85ced300-c5a5-11e8-9512-f105e11e71a5.png)

10. On the **Application Registration Portal**, login with your Microsoft username/password

![App Registration Portal Login](https://user-images.githubusercontent.com/13558917/46318743-86676980-c5a5-11e8-8843-e6d492dda7a3.png)

11. On the **My applications** page, select **Add an app**

![Add an app](https://user-images.githubusercontent.com/13558917/46318742-86676980-c5a5-11e8-8086-e08f0033d377.png)

12. On the **Register applications** page, create a name for your app
13. On the **Register applications** page, select **Create**

![Register you application](https://user-images.githubusercontent.com/13558917/46318741-86676980-c5a5-11e8-9963-408b8aeaebd8.png)

14. On the **App Registration** page, select **Generate New Password**

![Generate new password](https://user-images.githubusercontent.com/13558917/46318740-86676980-c5a5-11e8-9132-3c6f6430c076.png)

15. On the **New password generated** popup, copy the password and paste it in a text file on your local computer
    - **Note:** We will use this password later, but you will be unable to access the password after clicking **Ok** and closing the popup
16. On the **New password generated** popup, select **Ok**

![App Password](https://user-images.githubusercontent.com/13558917/46318931-2ae9ab80-c5a6-11e8-88c7-2c0bbabf8718.png)

17. On the **Register applications** page, in **Home page URL**, locate the **Application Id**
    - **Note:** We will use Application Id later
17. On the **Register applications** page, in **Home page URL**, paste the formatted App Service URL
    - **Formatted App Service Url:** `[Your App Service Url]/.auth/login/microsoftaccount/callback`
    - E.g., https://minnickhotelsweb.azurewebsites.net/.auth/login/microsoftaccount/callback
18. On the **Register applications** page, click **Save**

![Register Application](https://user-images.githubusercontent.com/13558917/46318738-85ced300-c5a5-11e8-9eeb-57ea23c15c56.png)

19. On the **Azure Portal** on the **Microsoft Account Authentication Settings** page, enter the following values:
    - **Client Id:** [Your Microsoft Application Id]
    - **Client Secret:** [Your Microsoft Application Password]
20. On the **Microsoft Account Authentication Settings** page, select **Ok**

![Microsoft Auth Settings](https://user-images.githubusercontent.com/13558917/46318737-85ced300-c5a5-11e8-9095-44b1c0f226a8.png)

21. On the **Authentication / Authorization** page, select **Save**

![Save Auth](https://user-images.githubusercontent.com/13558917/46318736-85ced300-c5a5-11e8-9c36-42bf0ff6278e.png)

## 10. Verify Auth (Azure)

1. Build/Deploy `hotelsweb.csproj` to the Azure Web App instance created earlier
2. Navigate to the Hotels360 website
3. On the Hotels360 website, ensure you are prompted with a Microsoft login
4. Enter your Microsoft user/name password
5. Grant login access to your app
