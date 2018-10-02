# Azure For Developers Workshop

The Azure cloud is huge (so that’s why they call it the cloud!) and the vast service catalog may appear daunting at first. It doesn’t have to be!

- Learn the browser-based UI of the Azure portal
- Continue the journey with the built-in, ready-to-run cloud shell
- Explore various ways to deploy web apps written in any language, on any platform, from virtual machines and containers to serverless technologies
- Add intelligence to your apps using Microsoft Cognitive Services
- Protect your apps by applying Azure’s built-in security features
- Diagnose problems and apply automated machine learning analysis with Application Insights
- Connect your apps with messaging services, load files into cloud storage and discover managed databases for SQL and NoSQL scenarios
- Tie everything together in a continuous delivery pipeline with Azure DevOps projects

## Agenda

### [1 - Intro to Azure](./presentation/) ([Jeremy Likness](https://twitter.com/jeremylikness))

Let's start by learning the Azure basics!

We'll start by showing the [different resources available in Azure](https://azure.microsoft.com/resources/?WT.mc_id=TechBash-github-bramin), then demonstrate how to access them via the [Azure Portal](https://azure.microsoft.com/features/azure-portal/?WT.mc_id=TechBash-github-bramin) and the [Azure Cloud Shell](https://azure.microsoft.com/features/cloud-shell/?WT.mc_id=TechBash-github-bramin).

### [2 - Azure Storage](./presentation/) ([Jeremy Likness](https://twitter.com/jeremylikness))

How do you store stuff in the cloud? In this section we'll explore [Azure Storage](https://azure.microsoft.com/free/storage/?WT.mc_id=TechBash-github-bramin) options including [Azure Blob Storage](https://azure.microsoft.com/services/storage/blobs/?WT.mc_id=TechBash-github-bramin) and [Azure File Storage](https://azure.microsoft.com/services/storage/files/?WT.mc_id=TechBash-github-bramin).

### [3 - Hosting in Azure](labs/03-hosting.md) ([Anthony Chu](https://twitter.com/@anthonychu))

In this section, we'll deploy our first website to Azure using [Azure App Service](https://azure.microsoft.com/services/app-service/?WT.mc_id=TechBash-github-bramin). Then we'll connect it with [Azure App Insights](https://docs.microsoft.com/azure/application-insights/app-insights-overview/?WT.mc_id=TechBash-github-bramin) for advanced logging and rich analytics.

### [4 - Azure Serverless](labs/04-serverless.md) ([Anthony Chu](https://twitter.com/@anthonychu))

Serverless today is all the rage! In this section we'll create our first serverless workflow using [Azure Functions](https://azure.microsoft.com/en-us/services/functions/?WT.mc_id=TechBash-github-bramin).

### 5 - DevOps ([Anthony Chu](https://twitter.com/@anthonychu))

Sit back and relax while we demonstrate how to create a CI/CD pipeline using [Azure Devops](https://azure.microsoft.com/services/devops/?WT.mc_id=TechBash-github-bramin).

### [6 - Cognitive Services](/labs/06-cognitive_services.md) ([Brandon Minnick](https://twitter.com/TheCodeTraveler))

Let's add some AI to our app! In this section we will add Sentiment Analysis to the reviews for our Hotels 360 app. For this, we will be leveraging the [Text Analytics API hosted by Cognitive Services](https://azure.microsoft.com/services/cognitive-services/text-analytics/?WT.mc_id=TechBash-github-bramin)

### [7 - Azure Security](/labs/07-azure_security.md) ([Brandon Minnick](https://twitter.com/TheCodeTraveler))

In this section we will learn how to leverage the security tools available in Azure.

We'll start by learning more about [Azure Security Center](https://azure.microsoft.com/services/security-center/?WT.mc_id=TechBash-github-bramin) and how to leverage its recommendations to add extra layers of security to our app service.

Next, we'll move the secrets out our code and into [Azure Key Vault](https://azure.microsoft.com/services/key-vault/?WT.mc_id=TechBash-github-bramin). Key Vault leverages HSMs (hardware security modules) to help us avoid storing secrets in our source code.

### 8 - Azure and Mobile ([Brandon Minnick](https://twitter.com/TheCodeTraveler))

If time permits, our resident mobile app expert, Brandon, will show how we can leverage our existing .NET skills to create mobile apps with [Xamarin](https://visualstudio.microsoft.com/xamarin/?WT.mc_id=TechBash-github-bramin) and [Azure](azure.com/?WT.mc_id=TechBash-github-bramin).

Sit back, releax and enjoy!
