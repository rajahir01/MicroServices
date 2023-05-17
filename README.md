# MicroServices
Learning &amp; Implementing MicroServices using .NET 
# TimerTrigger - C<span>#</span>

The `TimerTrigger` makes it incredibly easy to have your functions executed on a schedule. This sample demonstrates a simple use case of calling your function every 5 minutes.

## How it works

For a `TimerTrigger` to work, you provide a schedule in the form of a [cron expression](https://en.wikipedia.org/wiki/Cron#CRON_expression)(See the link for full details). A cron expression is a string with 6 separate expressions which represent a given schedule via patterns. The pattern we use to represent every 5 minutes is `0 */5 * * * *`. This, in plain text, means: "When seconds is equal to 0, minutes is divisible by 5, for any hour, day of the month, month, day of the week, or year".

## High Level Architecture
![AF](https://github.com/rajahir01/MicroServices/assets/66768536/e76d767d-dca4-4763-9b53-6ea592b84953)

The Serverless Azure Functions for Stack Overflow Integration with Slack project aims to create a seamless and automated solution for retrieving questions from the Stack Overflow API and sending them to a designated Slack channel. By leveraging the power of serverless computing and integrating with popular APIs, this project streamlines the process of gathering relevant questions and promotes efficient knowledge sharing within a Slack community.

The main objective of the project is to develop a serverless architecture using Azure Functions that periodically fetches questions from the Stack Overflow API based on specified criteria. The retrieved questions are then formatted and posted to a designated Slack channel, allowing team members or community members to stay up-to-date with the latest inquiries and contribute their expertise.

<TODO> Documentation
