import { test, expect } from "@playwright/test";
import { ExampleClass } from "../pages/appointments.page";

test("Navigate to appointments", async ({ page }) => {
  await page.goto("/appointments");
  const url = page.url();
  expect(url).toContain("appointments");
});

test("Search for Breed", async ({ page }) => {
  await page.goto("/appointments");
  let exampletest = new ExampleClass(page);
  var text = await exampletest.getBreedText();
  expect(text).toContain("Ockenburg");
});
