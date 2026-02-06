//sk - proj - tqyOEms - l68SoKN0FZWcDIxu5EuhxJyoSchXD5V0fq4eQH3DjITUZ2WAwtMFZN2lA - MoL8zNwaT3BlbkFJS - _Nb24 - y6yoVTi05KRXg89qKgZnUPcD - CGKG2G_0g1wTO1QNGhGjMOKNQLBj5sH3BZJXmdfsA



using OpenAI;
using OpenAI.Chat;

OpenAIClient client = new OpenAIClient(new System.ClientModel.ApiKeyCredential("KEY"));

ChatClient chatService = client.GetChatClient("gpt-4o-mini");

var result = await chatService.CompleteChatAsync("What is Color of Sky?");
Console.WriteLine(result);