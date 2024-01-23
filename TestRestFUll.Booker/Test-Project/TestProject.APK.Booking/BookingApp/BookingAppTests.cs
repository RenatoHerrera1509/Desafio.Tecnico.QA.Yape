using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.APK.Booking.Fixture;

namespace TestProject.APK.Booking.BookingApp
{
    public class BookingAppTests : IClassFixture<AppiumFixture>
    {
        private readonly AppiumFixture _appiumFixture;

        public BookingAppTests(AppiumFixture appiumFixture)
        {
            _appiumFixture = appiumFixture;
        }

        [Fact]
        [Obsolete]
        public void TestBookingFlow()
        {
            WebDriverWait wait = new WebDriverWait(_appiumFixture.Driver, TimeSpan.FromSeconds(10));

            // Buscar el elemento por su content-desc y hacer clic si está presente
            var navigateUpButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.widget.ImageButton[@content-desc=\"Navigate up\"]")));
            navigateUpButton.Click();

            // 1. Hacer clic para buscar el destino
            var searchDestination = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("com.booking:id/facet_search_box_basic_field_label")));
            searchDestination.Click();

            // 2. Ingresar el destino (ejemplo: "Cuzco")
            var enterDestination = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("com.booking:id/facet_with_bui_free_search_booking_header_toolbar_content")));
            enterDestination.SendKeys("Cusco");

            // 2.1 Seleccionar el primer elemento de la lista de resultados
            var firstResult = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.view.ViewGroup[@index='1']")));
            firstResult.Click();

            // 3. Seleccionar las fechas
            var selectStartDate = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.view.View[@content-desc=\"14 February 2024\"]")));
            selectStartDate.Click();
            var selectEndDate = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.view.View[@content-desc=\"28 February 2024\"]")));
            selectEndDate.Click();

            // 4. Confirmar las fechas
            var confirmDates = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("com.booking:id/facet_date_picker_confirm")));
            confirmDates.Click();

            // 5. Realizar la búsqueda de alojamiento
            var searchAccommodation = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("com.booking:id/facet_search_box_cta")));
            searchAccommodation.Click();

            // 6. Seleccionar la segunda opción de alojamiento
            var selectSecondOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//androidx.recyclerview.widget.RecyclerView/android.view.ViewGroup[4]/android.view.ViewGroup/android.view.ViewGroup[2]")));
            selectSecondOption.Click();

            // 7. Seleccionar habitación
            var selectRoom = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("com.booking:id/property_availability_cta_facetframe")));
            selectRoom.Click();

            // 8. Reservar
            var bedButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.widget.RadioButton[@text='1 bed']")));
            bedButton.Click();
            var selectButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.widget.LinearLayout[@resource-id='com.booking:id/rooms_item_select_layout']")));
            selectButton.Click();
            var reserveButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//android.widget.Button[@resource-id='com.booking:id/main_action']")));
            reserveButton.Click();

            // Aquí termina el flujo de prueba hasta la pantalla de registro de datos
        }
    }
}
