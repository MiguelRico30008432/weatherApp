using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace WpfApp1
{
	public class forecastAPI : baseAPI 
	{
		private WeatherModel t;
        private List <LocationModel> l;
		private dataBase db = new dataBase();



        public List<LocationModel> getLocationID(string parameter) 
		{
			string locationID = "";
			var host = "ai-weather-by-meteosource.p.rapidapi.com";
			var fullParameter = "text=" + parameter;
			var endpoint = "find_places";
			var url = "https://ai-weather-by-meteosource.p.rapidapi.com/" + endpoint + "?" + fullParameter;
            string result = "[{\"name\":\"Cascais\",\"place_id\":\"cascais\",\"adm_area1\":\"Cascais\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.69681N\",\"lon\":\"9.42147W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"settlement\"},{\"name\":\"Cascais Municipality\",\"place_id\":\"cascais-8010561\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.74333N\",\"lon\":\"9.46382W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"administrative_area\"},{\"name\":\"Cascais\",\"place_id\":\"cascais-8012457\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.72527N\",\"lon\":\"9.47189W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"administrative_area\"},{\"name\":\"Estoril\",\"place_id\":\"estoril\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.70571N\",\"lon\":\"9.39773W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"settlement\"},{\"name\":\"São Domingos de Rana\",\"place_id\":\"sao-domingos-de-rana\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.70194N\",\"lon\":\"9.34083W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"settlement\"},{\"name\":\"Alcabideche\",\"place_id\":\"alcabideche\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.73366N\",\"lon\":\"9.40928W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"settlement\"},{\"name\":\"Monte Estoril\",\"place_id\":\"monte-estoril\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.70636N\",\"lon\":\"9.40595W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"settlement\"},{\"name\":\"São Domingos de Rana\",\"place_id\":\"sao-domingos-de-rana-8014743\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.72289N\",\"lon\":\"9.33921W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"administrative_area\"},{\"name\":\"Alcabideche\",\"place_id\":\"alcabideche-8012455\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.74206N\",\"lon\":\"9.42143W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"administrative_area\"},{\"name\":\"Estoril\",\"place_id\":\"estoril-8012458\",\"adm_area1\":\"Lisbon District\",\"adm_area2\":\"Cascais Municipality\",\"country\":\"Portuguese Republic\",\"lat\":\"38.70971N\",\"lon\":\"9.38979W\",\"timezone\":\"Europe/Lisbon\",\"type\":\"administrative_area\"}]";

            try 
			{
				result = sendRequest(url, "get", host, null);
                l = JsonConvert.DeserializeObject<List<LocationModel>>(result);
                //l = JsonConvert.DeserializeObject<List<LocationModel>>(result);      
                db.insertLogs("location", result);
            }
            catch (Exception e) {
				MessageBox.Show(e.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}

            return l;
		}


		public WeatherModel getForecast(string parameter) 
		{
			WeatherModel t = new WeatherModel();

			var host = "ai-weather-by-meteosource.p.rapidapi.com";
			var fullParameter = "place_id=" + parameter + "&language=en&units=metric";
			var endpoint = "daily";
			var url = "https://ai-weather-by-meteosource.p.rapidapi.com/" + endpoint + "?" + fullParameter;
			var result = "\r\n                {\r\n                  \"lat\": \"38.71667N\",\r\n                  \"lon\": \"9.13333W\",\r\n                  \"elevation\": 45,\r\n                  \"units\": \"metric\",\r\n                  \"daily\": {\r\n                    \"data\": [\r\n                      {\r\n                        \"day\": \"2023-06-26\",\r\n                        \"weather\": \"mostly_sunny\",\r\n                        \"icon\": 3,\r\n                        \"summary\": \"Sunny. Temperature 20/32 °C. Wind from NW in the afternoon.\",\r\n                        \"predictability\": 1,\r\n                        \"temperature\": 24.5,\r\n                        \"temperature_min\": 19.5,\r\n                        \"temperature_max\": 32,\r\n                        \"feels_like\": 23.8,\r\n                        \"feels_like_min\": 20,\r\n                        \"feels_like_max\": 30.2,\r\n                        \"wind_chill\": 26,\r\n                        \"wind_chill_min\": 19.8,\r\n                        \"wind_chill_max\": 35.2,\r\n                        \"dew_point\": 11.8,\r\n                        \"dew_point_min\": 6,\r\n                        \"dew_point_max\": 16.2,\r\n                        \"wind\": {\r\n                          \"speed\": 5.3,\r\n                          \"gusts\": 12.8,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 348\r\n                        },\r\n                        \"cloud_cover\": 8,\r\n                        \"pressure\": 1018,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 308.56,\r\n                        \"humidity\": 49,\r\n                        \"visibility\": 24.13\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-06-27\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 19/30 °C. Wind from NW in the afternoon.\",\r\n                        \"predictability\": 3,\r\n                        \"temperature\": 23,\r\n                        \"temperature_min\": 18.8,\r\n                        \"temperature_max\": 29.5,\r\n                        \"feels_like\": 22.8,\r\n                        \"feels_like_min\": 19.8,\r\n                        \"feels_like_max\": 28.8,\r\n                        \"wind_chill\": 24,\r\n                        \"wind_chill_min\": 18.8,\r\n                        \"wind_chill_max\": 32.2,\r\n                        \"dew_point\": 14.5,\r\n                        \"dew_point_min\": 10.8,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 5.5,\r\n                          \"gusts\": 13.2,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 341\r\n                        },\r\n                        \"cloud_cover\": 3,\r\n                        \"pressure\": 1016,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 314.4,\r\n                        \"humidity\": 61,\r\n                        \"visibility\": 24.14\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-06-28\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 19/30 °C. Wind from NW in the afternoon.\",\r\n                        \"predictability\": 3,\r\n                        \"temperature\": 23,\r\n                        \"temperature_min\": 19,\r\n                        \"temperature_max\": 29.8,\r\n                        \"feels_like\": 22.5,\r\n                        \"feels_like_min\": 18,\r\n                        \"feels_like_max\": 29,\r\n                        \"wind_chill\": 24,\r\n                        \"wind_chill_min\": 19,\r\n                        \"wind_chill_max\": 33,\r\n                        \"dew_point\": 14.8,\r\n                        \"dew_point_min\": 13,\r\n                        \"dew_point_max\": 16.8,\r\n                        \"wind\": {\r\n                          \"speed\": 6.3,\r\n                          \"gusts\": 16.5,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 343\r\n                        },\r\n                        \"cloud_cover\": 2,\r\n                        \"pressure\": 1014,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 305.99,\r\n                        \"humidity\": 61,\r\n                        \"visibility\": 24.14\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-06-29\",\r\n                        \"weather\": \"partly_sunny\",\r\n                        \"icon\": 4,\r\n                        \"summary\": \"Sunny, more clouds in the afternoon and evening. Temperature 18/25 °C. Wind from NW.\",\r\n                        \"predictability\": 3,\r\n                        \"temperature\": 20.8,\r\n                        \"temperature_min\": 18,\r\n                        \"temperature_max\": 25.2,\r\n                        \"feels_like\": 18.2,\r\n                        \"feels_like_min\": 15,\r\n                        \"feels_like_max\": 22.5,\r\n                        \"wind_chill\": 20.8,\r\n                        \"wind_chill_min\": 17,\r\n                        \"wind_chill_max\": 26.5,\r\n                        \"dew_point\": 14,\r\n                        \"dew_point_min\": 13,\r\n                        \"dew_point_max\": 15.5,\r\n                        \"wind\": {\r\n                          \"speed\": 8.8,\r\n                          \"gusts\": 18.4,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 341\r\n                        },\r\n                        \"cloud_cover\": 17,\r\n                        \"pressure\": 1017,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 305.91,\r\n                        \"humidity\": 66,\r\n                        \"visibility\": 24.13\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-06-30\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 17/25 °C. Wind from N.\",\r\n                        \"predictability\": 3,\r\n                        \"temperature\": 20.2,\r\n                        \"temperature_min\": 17,\r\n                        \"temperature_max\": 25,\r\n                        \"feels_like\": 17.5,\r\n                        \"feels_like_min\": 14.2,\r\n                        \"feels_like_max\": 22.8,\r\n                        \"wind_chill\": 20.5,\r\n                        \"wind_chill_min\": 15.8,\r\n                        \"wind_chill_max\": 27.5,\r\n                        \"dew_point\": 10.8,\r\n                        \"dew_point_min\": 7.8,\r\n                        \"dew_point_max\": 14,\r\n                        \"wind\": {\r\n                          \"speed\": 7.9,\r\n                          \"gusts\": 19,\r\n                          \"dir\": \"N\",\r\n                          \"angle\": 351\r\n                        },\r\n                        \"cloud_cover\": 6,\r\n                        \"pressure\": 1017,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 316.14,\r\n                        \"humidity\": 57,\r\n                        \"visibility\": 24.13\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-01\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 18/29 °C. Wind from N.\",\r\n                        \"predictability\": 3,\r\n                        \"temperature\": 22.8,\r\n                        \"temperature_min\": 17.5,\r\n                        \"temperature_max\": 28.5,\r\n                        \"feels_like\": 21,\r\n                        \"feels_like_min\": 15.8,\r\n                        \"feels_like_max\": 28.8,\r\n                        \"wind_chill\": 23,\r\n                        \"wind_chill_min\": 16.8,\r\n                        \"wind_chill_max\": 32.2,\r\n                        \"dew_point\": 12,\r\n                        \"dew_point_min\": 5.8,\r\n                        \"dew_point_max\": 15.5,\r\n                        \"wind\": {\r\n                          \"speed\": 6.3,\r\n                          \"gusts\": 17,\r\n                          \"dir\": \"N\",\r\n                          \"angle\": 349\r\n                        },\r\n                        \"cloud_cover\": 4,\r\n                        \"pressure\": 1014,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 314.84,\r\n                        \"humidity\": 54,\r\n                        \"visibility\": 24.14\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-02\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 20/29 °C. Wind from NW in the afternoon.\",\r\n                        \"predictability\": 3,\r\n                        \"temperature\": 23.5,\r\n                        \"temperature_min\": 19.5,\r\n                        \"temperature_max\": 29.2,\r\n                        \"feels_like\": 24.2,\r\n                        \"feels_like_min\": 19.2,\r\n                        \"feels_like_max\": 33.5,\r\n                        \"wind_chill\": 25,\r\n                        \"wind_chill_min\": 20.2,\r\n                        \"wind_chill_max\": 34,\r\n                        \"dew_point\": 14.2,\r\n                        \"dew_point_min\": 11,\r\n                        \"dew_point_max\": 16.8,\r\n                        \"wind\": {\r\n                          \"speed\": 4.4,\r\n                          \"gusts\": 14.6,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 337\r\n                        },\r\n                        \"cloud_cover\": 6,\r\n                        \"pressure\": 1013,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 309.96,\r\n                        \"humidity\": 59,\r\n                        \"visibility\": 24.13\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-03\",\r\n                        \"weather\": \"mostly_sunny\",\r\n                        \"icon\": 3,\r\n                        \"summary\": \"Sunny, more clouds in the afternoon. Temperature 18/25 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.8,\r\n                        \"temperature_min\": 18.2,\r\n                        \"temperature_max\": 25.2,\r\n                        \"feels_like\": 20.2,\r\n                        \"feels_like_min\": 17.8,\r\n                        \"feels_like_max\": 22.2,\r\n                        \"wind_chill\": 20.5,\r\n                        \"wind_chill_min\": 18.8,\r\n                        \"wind_chill_max\": 24.2,\r\n                        \"dew_point\": 15.5,\r\n                        \"dew_point_min\": 13.5,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 5.9,\r\n                          \"gusts\": 13.9,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 338\r\n                        },\r\n                        \"cloud_cover\": 24,\r\n                        \"pressure\": 1016,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 2,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 305.33,\r\n                        \"humidity\": 73,\r\n                        \"visibility\": 24.12\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-04\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 19/23 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.5,\r\n                        \"temperature_min\": 18.8,\r\n                        \"temperature_max\": 23,\r\n                        \"feels_like\": 19,\r\n                        \"feels_like_min\": 17.5,\r\n                        \"feels_like_max\": 22,\r\n                        \"wind_chill\": 20.5,\r\n                        \"wind_chill_min\": 18.2,\r\n                        \"wind_chill_max\": 23.5,\r\n                        \"dew_point\": 16.2,\r\n                        \"dew_point_min\": 16,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 8,\r\n                          \"gusts\": 13.8,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 346\r\n                        },\r\n                        \"cloud_cover\": 0,\r\n                        \"pressure\": 1018,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 304.82,\r\n                        \"humidity\": 77,\r\n                        \"visibility\": 24.07\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-05\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 19/23 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.5,\r\n                        \"temperature_min\": 19,\r\n                        \"temperature_max\": 22.8,\r\n                        \"feels_like\": 19,\r\n                        \"feels_like_min\": 17.8,\r\n                        \"feels_like_max\": 21.2,\r\n                        \"wind_chill\": 20.5,\r\n                        \"wind_chill_min\": 18.5,\r\n                        \"wind_chill_max\": 23.2,\r\n                        \"dew_point\": 16,\r\n                        \"dew_point_min\": 15.5,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 8,\r\n                          \"gusts\": 12.7,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 343\r\n                        },\r\n                        \"cloud_cover\": 1,\r\n                        \"pressure\": 1017,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 1,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 305.42,\r\n                        \"humidity\": 74,\r\n                        \"visibility\": 24.1\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-06\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 19/23 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.2,\r\n                        \"temperature_min\": 18.5,\r\n                        \"temperature_max\": 22.8,\r\n                        \"feels_like\": 18.8,\r\n                        \"feels_like_min\": 17.2,\r\n                        \"feels_like_max\": 21.2,\r\n                        \"wind_chill\": 20,\r\n                        \"wind_chill_min\": 17.5,\r\n                        \"wind_chill_max\": 23.2,\r\n                        \"dew_point\": 15.5,\r\n                        \"dew_point_min\": 14.8,\r\n                        \"dew_point_max\": 16,\r\n                        \"wind\": {\r\n                          \"speed\": 8,\r\n                          \"gusts\": 12.1,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 345\r\n                        },\r\n                        \"cloud_cover\": 4,\r\n                        \"pressure\": 1016,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 2,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 311.33,\r\n                        \"humidity\": 73,\r\n                        \"visibility\": 24.07\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-07\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 18/22 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20,\r\n                        \"temperature_min\": 18,\r\n                        \"temperature_max\": 22.2,\r\n                        \"feels_like\": 18,\r\n                        \"feels_like_min\": 16.5,\r\n                        \"feels_like_max\": 20.2,\r\n                        \"wind_chill\": 19.5,\r\n                        \"wind_chill_min\": 17,\r\n                        \"wind_chill_max\": 22.8,\r\n                        \"dew_point\": 15.2,\r\n                        \"dew_point_min\": 14.8,\r\n                        \"dew_point_max\": 15.5,\r\n                        \"wind\": {\r\n                          \"speed\": 8.1,\r\n                          \"gusts\": 12.4,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 345\r\n                        },\r\n                        \"cloud_cover\": 6,\r\n                        \"pressure\": 1018,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 1,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 319.26,\r\n                        \"humidity\": 74,\r\n                        \"visibility\": 24.07\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-08\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 18/23 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.2,\r\n                        \"temperature_min\": 18,\r\n                        \"temperature_max\": 23,\r\n                        \"feels_like\": 18.8,\r\n                        \"feels_like_min\": 17.2,\r\n                        \"feels_like_max\": 22,\r\n                        \"wind_chill\": 20,\r\n                        \"wind_chill_min\": 17.5,\r\n                        \"wind_chill_max\": 23.5,\r\n                        \"dew_point\": 15.5,\r\n                        \"dew_point_min\": 15.5,\r\n                        \"dew_point_max\": 15.8,\r\n                        \"wind\": {\r\n                          \"speed\": 7.7,\r\n                          \"gusts\": 12.4,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 342\r\n                        },\r\n                        \"cloud_cover\": 1,\r\n                        \"pressure\": 1019,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 312.56,\r\n                        \"humidity\": 74,\r\n                        \"visibility\": 23.65\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-09\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny. Temperature 19/24 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.5,\r\n                        \"temperature_min\": 18.5,\r\n                        \"temperature_max\": 23.5,\r\n                        \"feels_like\": 19.8,\r\n                        \"feels_like_min\": 17.5,\r\n                        \"feels_like_max\": 23,\r\n                        \"wind_chill\": 20.5,\r\n                        \"wind_chill_min\": 18,\r\n                        \"wind_chill_max\": 24.5,\r\n                        \"dew_point\": 16,\r\n                        \"dew_point_min\": 15.2,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 7,\r\n                          \"gusts\": 11.4,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 336\r\n                        },\r\n                        \"cloud_cover\": 0,\r\n                        \"pressure\": 1017,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 0,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 311.36,\r\n                        \"humidity\": 75,\r\n                        \"visibility\": 23.02\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-10\",\r\n                        \"weather\": \"partly_sunny\",\r\n                        \"icon\": 4,\r\n                        \"summary\": \"Partly sunny, fewer clouds in the evening. Temperature 18/23 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.5,\r\n                        \"temperature_min\": 18.2,\r\n                        \"temperature_max\": 23.2,\r\n                        \"feels_like\": 20,\r\n                        \"feels_like_min\": 17.8,\r\n                        \"feels_like_max\": 22.8,\r\n                        \"wind_chill\": 20.8,\r\n                        \"wind_chill_min\": 18.2,\r\n                        \"wind_chill_max\": 23.8,\r\n                        \"dew_point\": 16.2,\r\n                        \"dew_point_min\": 15.2,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 6.1,\r\n                          \"gusts\": 10.1,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 333\r\n                        },\r\n                        \"cloud_cover\": 20,\r\n                        \"pressure\": 1016,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 7,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 307.78,\r\n                        \"humidity\": 76,\r\n                        \"visibility\": 22.76\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-11\",\r\n                        \"weather\": \"mostly_sunny\",\r\n                        \"icon\": 3,\r\n                        \"summary\": \"Sunny. Temperature 19/23 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.8,\r\n                        \"temperature_min\": 18.5,\r\n                        \"temperature_max\": 23.2,\r\n                        \"feels_like\": 20,\r\n                        \"feels_like_min\": 18.8,\r\n                        \"feels_like_max\": 22.2,\r\n                        \"wind_chill\": 20.8,\r\n                        \"wind_chill_min\": 18.5,\r\n                        \"wind_chill_max\": 23.8,\r\n                        \"dew_point\": 16.5,\r\n                        \"dew_point_min\": 16,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 6.7,\r\n                          \"gusts\": 11.9,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 338\r\n                        },\r\n                        \"cloud_cover\": 7,\r\n                        \"pressure\": 1015,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 11,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 314.43,\r\n                        \"humidity\": 76,\r\n                        \"visibility\": 24.1\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-12\",\r\n                        \"weather\": \"mostly_sunny\",\r\n                        \"icon\": 3,\r\n                        \"summary\": \"Sunny. Temperature 19/23 °C. Wind from NW in the afternoon.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.5,\r\n                        \"temperature_min\": 18.5,\r\n                        \"temperature_max\": 23.2,\r\n                        \"feels_like\": 20.5,\r\n                        \"feels_like_min\": 18.8,\r\n                        \"feels_like_max\": 23.2,\r\n                        \"wind_chill\": 20.5,\r\n                        \"wind_chill_min\": 18,\r\n                        \"wind_chill_max\": 23.8,\r\n                        \"dew_point\": 16.5,\r\n                        \"dew_point_min\": 15.8,\r\n                        \"dew_point_max\": 16.8,\r\n                        \"wind\": {\r\n                          \"speed\": 5.8,\r\n                          \"gusts\": 10.4,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 338\r\n                        },\r\n                        \"cloud_cover\": 7,\r\n                        \"pressure\": 1017,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 13,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 308.72,\r\n                        \"humidity\": 77,\r\n                        \"visibility\": 23.32\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-13\",\r\n                        \"weather\": \"mostly_sunny\",\r\n                        \"icon\": 3,\r\n                        \"summary\": \"Partly sunny, fewer clouds in the afternoon and evening. Temperature 19/23 °C.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 20.8,\r\n                        \"temperature_min\": 18.5,\r\n                        \"temperature_max\": 23.2,\r\n                        \"feels_like\": 21.2,\r\n                        \"feels_like_min\": 18.8,\r\n                        \"feels_like_max\": 24.2,\r\n                        \"wind_chill\": 21,\r\n                        \"wind_chill_min\": 18.5,\r\n                        \"wind_chill_max\": 24.2,\r\n                        \"dew_point\": 16.5,\r\n                        \"dew_point_min\": 15.8,\r\n                        \"dew_point_max\": 16.8,\r\n                        \"wind\": {\r\n                          \"speed\": 4.9,\r\n                          \"gusts\": 10.2,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 336\r\n                        },\r\n                        \"cloud_cover\": 8,\r\n                        \"pressure\": 1017,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 18,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 310.39,\r\n                        \"humidity\": 77,\r\n                        \"visibility\": 23.01\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-14\",\r\n                        \"weather\": \"mostly_sunny\",\r\n                        \"icon\": 3,\r\n                        \"summary\": \"Sunny, more clouds in the afternoon and evening. Temperature 19/24 °C.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 21.2,\r\n                        \"temperature_min\": 18.8,\r\n                        \"temperature_max\": 24.2,\r\n                        \"feels_like\": 21.5,\r\n                        \"feels_like_min\": 19,\r\n                        \"feels_like_max\": 24.8,\r\n                        \"wind_chill\": 21.5,\r\n                        \"wind_chill_min\": 18.5,\r\n                        \"wind_chill_max\": 25.2,\r\n                        \"dew_point\": 16,\r\n                        \"dew_point_min\": 15,\r\n                        \"dew_point_max\": 16.8,\r\n                        \"wind\": {\r\n                          \"speed\": 5.5,\r\n                          \"gusts\": 10.7,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 341\r\n                        },\r\n                        \"cloud_cover\": 19,\r\n                        \"pressure\": 1017,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 1,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 306.85,\r\n                        \"humidity\": 72,\r\n                        \"visibility\": 23.63\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-15\",\r\n                        \"weather\": \"partly_sunny\",\r\n                        \"icon\": 4,\r\n                        \"summary\": \"Partly sunny, fewer clouds in the afternoon and evening. Temperature 20/24 °C. Wind from NW in the afternoon.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 21.5,\r\n                        \"temperature_min\": 19.5,\r\n                        \"temperature_max\": 24,\r\n                        \"feels_like\": 21.2,\r\n                        \"feels_like_min\": 19.8,\r\n                        \"feels_like_max\": 24,\r\n                        \"wind_chill\": 21.8,\r\n                        \"wind_chill_min\": 19.5,\r\n                        \"wind_chill_max\": 25,\r\n                        \"dew_point\": 16.8,\r\n                        \"dew_point_min\": 16.2,\r\n                        \"dew_point_max\": 17.2,\r\n                        \"wind\": {\r\n                          \"speed\": 6.3,\r\n                          \"gusts\": 11.9,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 342\r\n                        },\r\n                        \"cloud_cover\": 26,\r\n                        \"pressure\": 1018,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 10,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 303.91,\r\n                        \"humidity\": 74,\r\n                        \"visibility\": 24.04\r\n                      },\r\n                      {\r\n                        \"day\": \"2023-07-16\",\r\n                        \"weather\": \"sunny\",\r\n                        \"icon\": 2,\r\n                        \"summary\": \"Sunny, more clouds in the evening. Temperature 19/24 °C. Wind from NW.\",\r\n                        \"predictability\": 4,\r\n                        \"temperature\": 21.2,\r\n                        \"temperature_min\": 19,\r\n                        \"temperature_max\": 24,\r\n                        \"feels_like\": 21,\r\n                        \"feels_like_min\": 18.2,\r\n                        \"feels_like_max\": 24,\r\n                        \"wind_chill\": 21.5,\r\n                        \"wind_chill_min\": 18.5,\r\n                        \"wind_chill_max\": 25,\r\n                        \"dew_point\": 16.5,\r\n                        \"dew_point_min\": 16.2,\r\n                        \"dew_point_max\": 16.5,\r\n                        \"wind\": {\r\n                          \"speed\": 6.1,\r\n                          \"gusts\": 11.5,\r\n                          \"dir\": \"NNW\",\r\n                          \"angle\": 342\r\n                        },\r\n                        \"cloud_cover\": 8,\r\n                        \"pressure\": 1018,\r\n                        \"precipitation\": {\r\n                          \"total\": 0,\r\n                          \"type\": \"none\"\r\n                        },\r\n                        \"probability\": {\r\n                          \"precipitation\": 3,\r\n                          \"storm\": 0,\r\n                          \"freeze\": 0\r\n                        },\r\n                        \"ozone\": 303.11,\r\n                        \"humidity\": 74,\r\n                        \"visibility\": 24.1\r\n                      }\r\n                    ]\r\n                  }\r\n                }";

			try
			{
				result = sendRequest(url, "get", host, null);
                t = JsonConvert.DeserializeObject<WeatherModel>(result);
                //t = JsonConvert.DeserializeObject<WeatherModel>(result);
                db.insertLogs("forecast", result);
            }
			catch(Exception e)
			{
				MessageBox.Show(e.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			return t;
		}
	}
}

//var result = @"{
//  ""lat"": ""38.71667N"",
//  ""lon"": ""9.13333W"",
//  ""elevation"": 45,
//  ""units"": ""metric"",
//  ""daily"": {
//    ""data"": [
//      {
//        ""day"": ""2023-06-26"",
//        ""weather"": ""mostly_sunny"",
//        ""icon"": 3,
//        ""summary"": ""Sunny. Temperature 20/32 °C. Wind from NW in the afternoon."",
//        ""predictability"": 1,
//        ""temperature"": 24.5,
//        ""temperature_min"": 19.5,
//        ""temperature_max"": 32,
//        ""feels_like"": 23.8,
//        ""feels_like_min"": 20,
//        ""feels_like_max"": 30.2,
//        ""wind_chill"": 26,
//        ""wind_chill_min"": 19.8,
//        ""wind_chill_max"": 35.2,
//        ""dew_point"": 11.8,
//        ""dew_point_min"": 6,
//        ""dew_point_max"": 16.2,
//        ""wind"": {
//          ""speed"": 5.3,
//          ""gusts"": 12.8,
//          ""dir"": ""NNW"",
//          ""angle"": 348
//        },
//        ""cloud_cover"": 8,
//        ""pressure"": 1018,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 308.56,
//        ""humidity"": 49,
//        ""visibility"": 24.13
//      },
//      {
//        ""day"": ""2023-06-27"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 19/30 °C. Wind from NW in the afternoon."",
//        ""predictability"": 3,
//        ""temperature"": 23,
//        ""temperature_min"": 18.8,
//        ""temperature_max"": 29.5,
//        ""feels_like"": 22.8,
//        ""feels_like_min"": 19.8,
//        ""feels_like_max"": 28.8,
//        ""wind_chill"": 24,
//        ""wind_chill_min"": 18.8,
//        ""wind_chill_max"": 32.2,
//        ""dew_point"": 14.5,
//        ""dew_point_min"": 10.8,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 5.5,
//          ""gusts"": 13.2,
//          ""dir"": ""NNW"",
//          ""angle"": 341
//        },
//        ""cloud_cover"": 3,
//        ""pressure"": 1016,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 314.4,
//        ""humidity"": 61,
//        ""visibility"": 24.14
//      },
//      {
//        ""day"": ""2023-06-28"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 19/30 °C. Wind from NW in the afternoon."",
//        ""predictability"": 3,
//        ""temperature"": 23,
//        ""temperature_min"": 19,
//        ""temperature_max"": 29.8,
//        ""feels_like"": 22.5,
//        ""feels_like_min"": 18,
//        ""feels_like_max"": 29,
//        ""wind_chill"": 24,
//        ""wind_chill_min"": 19,
//        ""wind_chill_max"": 33,
//        ""dew_point"": 14.8,
//        ""dew_point_min"": 13,
//        ""dew_point_max"": 16.8,
//        ""wind"": {
//          ""speed"": 6.3,
//          ""gusts"": 16.5,
//          ""dir"": ""NNW"",
//          ""angle"": 343
//        },
//        ""cloud_cover"": 2,
//        ""pressure"": 1014,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 305.99,
//        ""humidity"": 61,
//        ""visibility"": 24.14
//      },
//      {
//        ""day"": ""2023-06-29"",
//        ""weather"": ""partly_sunny"",
//        ""icon"": 4,
//        ""summary"": ""Sunny, more clouds in the afternoon and evening. Temperature 18/25 °C. Wind from NW."",
//        ""predictability"": 3,
//        ""temperature"": 20.8,
//        ""temperature_min"": 18,
//        ""temperature_max"": 25.2,
//        ""feels_like"": 18.2,
//        ""feels_like_min"": 15,
//        ""feels_like_max"": 22.5,
//        ""wind_chill"": 20.8,
//        ""wind_chill_min"": 17,
//        ""wind_chill_max"": 26.5,
//        ""dew_point"": 14,
//        ""dew_point_min"": 13,
//        ""dew_point_max"": 15.5,
//        ""wind"": {
//          ""speed"": 8.8,
//          ""gusts"": 18.4,
//          ""dir"": ""NNW"",
//          ""angle"": 341
//        },
//        ""cloud_cover"": 17,
//        ""pressure"": 1017,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 305.91,
//        ""humidity"": 66,
//        ""visibility"": 24.13
//      },
//      {
//        ""day"": ""2023-06-30"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 17/25 °C. Wind from N."",
//        ""predictability"": 3,
//        ""temperature"": 20.2,
//        ""temperature_min"": 17,
//        ""temperature_max"": 25,
//        ""feels_like"": 17.5,
//        ""feels_like_min"": 14.2,
//        ""feels_like_max"": 22.8,
//        ""wind_chill"": 20.5,
//        ""wind_chill_min"": 15.8,
//        ""wind_chill_max"": 27.5,
//        ""dew_point"": 10.8,
//        ""dew_point_min"": 7.8,
//        ""dew_point_max"": 14,
//        ""wind"": {
//          ""speed"": 7.9,
//          ""gusts"": 19,
//          ""dir"": ""N"",
//          ""angle"": 351
//        },
//        ""cloud_cover"": 6,
//        ""pressure"": 1017,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 316.14,
//        ""humidity"": 57,
//        ""visibility"": 24.13
//      },
//      {
//        ""day"": ""2023-07-01"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 18/29 °C. Wind from N."",
//        ""predictability"": 3,
//        ""temperature"": 22.8,
//        ""temperature_min"": 17.5,
//        ""temperature_max"": 28.5,
//        ""feels_like"": 21,
//        ""feels_like_min"": 15.8,
//        ""feels_like_max"": 28.8,
//        ""wind_chill"": 23,
//        ""wind_chill_min"": 16.8,
//        ""wind_chill_max"": 32.2,
//        ""dew_point"": 12,
//        ""dew_point_min"": 5.8,
//        ""dew_point_max"": 15.5,
//        ""wind"": {
//          ""speed"": 6.3,
//          ""gusts"": 17,
//          ""dir"": ""N"",
//          ""angle"": 349
//        },
//        ""cloud_cover"": 4,
//        ""pressure"": 1014,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 314.84,
//        ""humidity"": 54,
//        ""visibility"": 24.14
//      },
//      {
//        ""day"": ""2023-07-02"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 20/29 °C. Wind from NW in the afternoon."",
//        ""predictability"": 3,
//        ""temperature"": 23.5,
//        ""temperature_min"": 19.5,
//        ""temperature_max"": 29.2,
//        ""feels_like"": 24.2,
//        ""feels_like_min"": 19.2,
//        ""feels_like_max"": 33.5,
//        ""wind_chill"": 25,
//        ""wind_chill_min"": 20.2,
//        ""wind_chill_max"": 34,
//        ""dew_point"": 14.2,
//        ""dew_point_min"": 11,
//        ""dew_point_max"": 16.8,
//        ""wind"": {
//          ""speed"": 4.4,
//          ""gusts"": 14.6,
//          ""dir"": ""NNW"",
//          ""angle"": 337
//        },
//        ""cloud_cover"": 6,
//        ""pressure"": 1013,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 309.96,
//        ""humidity"": 59,
//        ""visibility"": 24.13
//      },
//      {
//        ""day"": ""2023-07-03"",
//        ""weather"": ""mostly_sunny"",
//        ""icon"": 3,
//        ""summary"": ""Sunny, more clouds in the afternoon. Temperature 18/25 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.8,
//        ""temperature_min"": 18.2,
//        ""temperature_max"": 25.2,
//        ""feels_like"": 20.2,
//        ""feels_like_min"": 17.8,
//        ""feels_like_max"": 22.2,
//        ""wind_chill"": 20.5,
//        ""wind_chill_min"": 18.8,
//        ""wind_chill_max"": 24.2,
//        ""dew_point"": 15.5,
//        ""dew_point_min"": 13.5,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 5.9,
//          ""gusts"": 13.9,
//          ""dir"": ""NNW"",
//          ""angle"": 338
//        },
//        ""cloud_cover"": 24,
//        ""pressure"": 1016,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 2,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 305.33,
//        ""humidity"": 73,
//        ""visibility"": 24.12
//      },
//      {
//        ""day"": ""2023-07-04"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 19/23 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.5,
//        ""temperature_min"": 18.8,
//        ""temperature_max"": 23,
//        ""feels_like"": 19,
//        ""feels_like_min"": 17.5,
//        ""feels_like_max"": 22,
//        ""wind_chill"": 20.5,
//        ""wind_chill_min"": 18.2,
//        ""wind_chill_max"": 23.5,
//        ""dew_point"": 16.2,
//        ""dew_point_min"": 16,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 8,
//          ""gusts"": 13.8,
//          ""dir"": ""NNW"",
//          ""angle"": 346
//        },
//        ""cloud_cover"": 0,
//        ""pressure"": 1018,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 304.82,
//        ""humidity"": 77,
//        ""visibility"": 24.07
//      },
//      {
//        ""day"": ""2023-07-05"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 19/23 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.5,
//        ""temperature_min"": 19,
//        ""temperature_max"": 22.8,
//        ""feels_like"": 19,
//        ""feels_like_min"": 17.8,
//        ""feels_like_max"": 21.2,
//        ""wind_chill"": 20.5,
//        ""wind_chill_min"": 18.5,
//        ""wind_chill_max"": 23.2,
//        ""dew_point"": 16,
//        ""dew_point_min"": 15.5,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 8,
//          ""gusts"": 12.7,
//          ""dir"": ""NNW"",
//          ""angle"": 343
//        },
//        ""cloud_cover"": 1,
//        ""pressure"": 1017,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 1,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 305.42,
//        ""humidity"": 74,
//        ""visibility"": 24.1
//      },
//      {
//        ""day"": ""2023-07-06"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 19/23 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.2,
//        ""temperature_min"": 18.5,
//        ""temperature_max"": 22.8,
//        ""feels_like"": 18.8,
//        ""feels_like_min"": 17.2,
//        ""feels_like_max"": 21.2,
//        ""wind_chill"": 20,
//        ""wind_chill_min"": 17.5,
//        ""wind_chill_max"": 23.2,
//        ""dew_point"": 15.5,
//        ""dew_point_min"": 14.8,
//        ""dew_point_max"": 16,
//        ""wind"": {
//          ""speed"": 8,
//          ""gusts"": 12.1,
//          ""dir"": ""NNW"",
//          ""angle"": 345
//        },
//        ""cloud_cover"": 4,
//        ""pressure"": 1016,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 2,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 311.33,
//        ""humidity"": 73,
//        ""visibility"": 24.07
//      },
//      {
//        ""day"": ""2023-07-07"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 18/22 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20,
//        ""temperature_min"": 18,
//        ""temperature_max"": 22.2,
//        ""feels_like"": 18,
//        ""feels_like_min"": 16.5,
//        ""feels_like_max"": 20.2,
//        ""wind_chill"": 19.5,
//        ""wind_chill_min"": 17,
//        ""wind_chill_max"": 22.8,
//        ""dew_point"": 15.2,
//        ""dew_point_min"": 14.8,
//        ""dew_point_max"": 15.5,
//        ""wind"": {
//          ""speed"": 8.1,
//          ""gusts"": 12.4,
//          ""dir"": ""NNW"",
//          ""angle"": 345
//        },
//        ""cloud_cover"": 6,
//        ""pressure"": 1018,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 1,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 319.26,
//        ""humidity"": 74,
//        ""visibility"": 24.07
//      },
//      {
//        ""day"": ""2023-07-08"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 18/23 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.2,
//        ""temperature_min"": 18,
//        ""temperature_max"": 23,
//        ""feels_like"": 18.8,
//        ""feels_like_min"": 17.2,
//        ""feels_like_max"": 22,
//        ""wind_chill"": 20,
//        ""wind_chill_min"": 17.5,
//        ""wind_chill_max"": 23.5,
//        ""dew_point"": 15.5,
//        ""dew_point_min"": 15.5,
//        ""dew_point_max"": 15.8,
//        ""wind"": {
//          ""speed"": 7.7,
//          ""gusts"": 12.4,
//          ""dir"": ""NNW"",
//          ""angle"": 342
//        },
//        ""cloud_cover"": 1,
//        ""pressure"": 1019,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 312.56,
//        ""humidity"": 74,
//        ""visibility"": 23.65
//      },
//      {
//        ""day"": ""2023-07-09"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny. Temperature 19/24 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.5,
//        ""temperature_min"": 18.5,
//        ""temperature_max"": 23.5,
//        ""feels_like"": 19.8,
//        ""feels_like_min"": 17.5,
//        ""feels_like_max"": 23,
//        ""wind_chill"": 20.5,
//        ""wind_chill_min"": 18,
//        ""wind_chill_max"": 24.5,
//        ""dew_point"": 16,
//        ""dew_point_min"": 15.2,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 7,
//          ""gusts"": 11.4,
//          ""dir"": ""NNW"",
//          ""angle"": 336
//        },
//        ""cloud_cover"": 0,
//        ""pressure"": 1017,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 0,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 311.36,
//        ""humidity"": 75,
//        ""visibility"": 23.02
//      },
//      {
//        ""day"": ""2023-07-10"",
//        ""weather"": ""partly_sunny"",
//        ""icon"": 4,
//        ""summary"": ""Partly sunny, fewer clouds in the evening. Temperature 18/23 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.5,
//        ""temperature_min"": 18.2,
//        ""temperature_max"": 23.2,
//        ""feels_like"": 20,
//        ""feels_like_min"": 17.8,
//        ""feels_like_max"": 22.8,
//        ""wind_chill"": 20.8,
//        ""wind_chill_min"": 18.2,
//        ""wind_chill_max"": 23.8,
//        ""dew_point"": 16.2,
//        ""dew_point_min"": 15.2,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 6.1,
//          ""gusts"": 10.1,
//          ""dir"": ""NNW"",
//          ""angle"": 333
//        },
//        ""cloud_cover"": 20,
//        ""pressure"": 1016,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 7,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 307.78,
//        ""humidity"": 76,
//        ""visibility"": 22.76
//      },
//      {
//        ""day"": ""2023-07-11"",
//        ""weather"": ""mostly_sunny"",
//        ""icon"": 3,
//        ""summary"": ""Sunny. Temperature 19/23 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 20.8,
//        ""temperature_min"": 18.5,
//        ""temperature_max"": 23.2,
//        ""feels_like"": 20,
//        ""feels_like_min"": 18.8,
//        ""feels_like_max"": 22.2,
//        ""wind_chill"": 20.8,
//        ""wind_chill_min"": 18.5,
//        ""wind_chill_max"": 23.8,
//        ""dew_point"": 16.5,
//        ""dew_point_min"": 16,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 6.7,
//          ""gusts"": 11.9,
//          ""dir"": ""NNW"",
//          ""angle"": 338
//        },
//        ""cloud_cover"": 7,
//        ""pressure"": 1015,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 11,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 314.43,
//        ""humidity"": 76,
//        ""visibility"": 24.1
//      },
//      {
//        ""day"": ""2023-07-12"",
//        ""weather"": ""mostly_sunny"",
//        ""icon"": 3,
//        ""summary"": ""Sunny. Temperature 19/23 °C. Wind from NW in the afternoon."",
//        ""predictability"": 4,
//        ""temperature"": 20.5,
//        ""temperature_min"": 18.5,
//        ""temperature_max"": 23.2,
//        ""feels_like"": 20.5,
//        ""feels_like_min"": 18.8,
//        ""feels_like_max"": 23.2,
//        ""wind_chill"": 20.5,
//        ""wind_chill_min"": 18,
//        ""wind_chill_max"": 23.8,
//        ""dew_point"": 16.5,
//        ""dew_point_min"": 15.8,
//        ""dew_point_max"": 16.8,
//        ""wind"": {
//          ""speed"": 5.8,
//          ""gusts"": 10.4,
//          ""dir"": ""NNW"",
//          ""angle"": 338
//        },
//        ""cloud_cover"": 7,
//        ""pressure"": 1017,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 13,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 308.72,
//        ""humidity"": 77,
//        ""visibility"": 23.32
//      },
//      {
//        ""day"": ""2023-07-13"",
//        ""weather"": ""mostly_sunny"",
//        ""icon"": 3,
//        ""summary"": ""Partly sunny, fewer clouds in the afternoon and evening. Temperature 19/23 °C."",
//        ""predictability"": 4,
//        ""temperature"": 20.8,
//        ""temperature_min"": 18.5,
//        ""temperature_max"": 23.2,
//        ""feels_like"": 21.2,
//        ""feels_like_min"": 18.8,
//        ""feels_like_max"": 24.2,
//        ""wind_chill"": 21,
//        ""wind_chill_min"": 18.5,
//        ""wind_chill_max"": 24.2,
//        ""dew_point"": 16.5,
//        ""dew_point_min"": 15.8,
//        ""dew_point_max"": 16.8,
//        ""wind"": {
//          ""speed"": 4.9,
//          ""gusts"": 10.2,
//          ""dir"": ""NNW"",
//          ""angle"": 336
//        },
//        ""cloud_cover"": 8,
//        ""pressure"": 1017,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 18,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 310.39,
//        ""humidity"": 77,
//        ""visibility"": 23.01
//      },
//      {
//        ""day"": ""2023-07-14"",
//        ""weather"": ""mostly_sunny"",
//        ""icon"": 3,
//        ""summary"": ""Sunny, more clouds in the afternoon and evening. Temperature 19/24 °C."",
//        ""predictability"": 4,
//        ""temperature"": 21.2,
//        ""temperature_min"": 18.8,
//        ""temperature_max"": 24.2,
//        ""feels_like"": 21.5,
//        ""feels_like_min"": 19,
//        ""feels_like_max"": 24.8,
//        ""wind_chill"": 21.5,
//        ""wind_chill_min"": 18.5,
//        ""wind_chill_max"": 25.2,
//        ""dew_point"": 16,
//        ""dew_point_min"": 15,
//        ""dew_point_max"": 16.8,
//        ""wind"": {
//          ""speed"": 5.5,
//          ""gusts"": 10.7,
//          ""dir"": ""NNW"",
//          ""angle"": 341
//        },
//        ""cloud_cover"": 19,
//        ""pressure"": 1017,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 1,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 306.85,
//        ""humidity"": 72,
//        ""visibility"": 23.63
//      },
//      {
//        ""day"": ""2023-07-15"",
//        ""weather"": ""partly_sunny"",
//        ""icon"": 4,
//        ""summary"": ""Partly sunny, fewer clouds in the afternoon and evening. Temperature 20/24 °C. Wind from NW in the afternoon."",
//        ""predictability"": 4,
//        ""temperature"": 21.5,
//        ""temperature_min"": 19.5,
//        ""temperature_max"": 24,
//        ""feels_like"": 21.2,
//        ""feels_like_min"": 19.8,
//        ""feels_like_max"": 24,
//        ""wind_chill"": 21.8,
//        ""wind_chill_min"": 19.5,
//        ""wind_chill_max"": 25,
//        ""dew_point"": 16.8,
//        ""dew_point_min"": 16.2,
//        ""dew_point_max"": 17.2,
//        ""wind"": {
//          ""speed"": 6.3,
//          ""gusts"": 11.9,
//          ""dir"": ""NNW"",
//          ""angle"": 342
//        },
//        ""cloud_cover"": 26,
//        ""pressure"": 1018,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 10,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 303.91,
//        ""humidity"": 74,
//        ""visibility"": 24.04
//      },
//      {
//        ""day"": ""2023-07-16"",
//        ""weather"": ""sunny"",
//        ""icon"": 2,
//        ""summary"": ""Sunny, more clouds in the evening. Temperature 19/24 °C. Wind from NW."",
//        ""predictability"": 4,
//        ""temperature"": 21.2,
//        ""temperature_min"": 19,
//        ""temperature_max"": 24,
//        ""feels_like"": 21,
//        ""feels_like_min"": 18.2,
//        ""feels_like_max"": 24,
//        ""wind_chill"": 21.5,
//        ""wind_chill_min"": 18.5,
//        ""wind_chill_max"": 25,
//        ""dew_point"": 16.5,
//        ""dew_point_min"": 16.2,
//        ""dew_point_max"": 16.5,
//        ""wind"": {
//          ""speed"": 6.1,
//          ""gusts"": 11.5,
//          ""dir"": ""NNW"",
//          ""angle"": 342
//        },
//        ""cloud_cover"": 8,
//        ""pressure"": 1018,
//        ""precipitation"": {
//          ""total"": 0,
//          ""type"": ""none""
//        },
//        ""probability"": {
//          ""precipitation"": 3,
//          ""storm"": 0,
//          ""freeze"": 0
//        },
//        ""ozone"": 303.11,
//        ""humidity"": 74,
//        ""visibility"": 24.1
//      }
//    ]
//  }
//}";