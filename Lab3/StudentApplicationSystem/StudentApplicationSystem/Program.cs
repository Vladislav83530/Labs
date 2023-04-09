﻿using Microsoft.Extensions.DependencyInjection;
using StudentApplicationSystem;
using StudentApplicationSystem.DataValidator;
using StudentApplicationSystem.DataValidator.Interfaces;
using StudentApplicationSystem.InputHandler;
using StudentApplicationSystem.InputHandler.Interfaces;

var serviceProvider = new ServiceCollection()
                .AddSingleton<IApplicantValidateService, ApplicantValidateService>()
                .AddSingleton<ITestResultValidateService, TestResultValidateService>()
                .AddSingleton<IConsoleWrapper, ConsoleWrapper>()
                .AddSingleton<IInputHandler, InputHandler>()
                .BuildServiceProvider();

var applicantValidateService = serviceProvider.GetRequiredService<IApplicantValidateService>();
var inputHandler = serviceProvider.GetRequiredService<IInputHandler>();
var consoleWrapper = serviceProvider.GetRequiredService<IConsoleWrapper>();

InputManager inputManager = new InputManager(inputHandler, applicantValidateService, consoleWrapper);
AppManager appManager = new AppManager(inputManager);
appManager.Run();